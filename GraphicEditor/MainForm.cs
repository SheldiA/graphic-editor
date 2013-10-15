using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Figures;
using System.Reflection;
using System.Reflection.Emit;
using System.Drawing.Imaging;

namespace GraphicEditor
{
    public partial class MainForm : Form
    {
        private IFigures current_object;
        private string current_figure_id = "";
        private List<figure_frame> all_figures;
        private List<IFigures> figures;
        private Color figure_color;
        private Color canvas_color;
        private Bitmap buf;
        private byte[] bufByte;
        Graphics gbuf;
        Graphics canvas;


        private List<string> all_types;
        private List<string> new_all_figures;
        private List<string> assemblyFileNames;
        private AppDomain domain;

        public enum FigureID { line, rectangle, triangle, ellipse, fillellipse };
        private struct figure_frame
        {
            public int Id;
            public Point First_Point;
            public Point Last_Point;
            public figure_frame(int id, Point first_point, Point last_point)
            {
                Id = id;
                First_Point = first_point;
                Last_Point = last_point; 
            }
        }
        
        bool OffOn;
        
        public MainForm()
        {
            InitializeComponent();
            all_figures = new List<figure_frame>();
            new_all_figures = new List<string>();
            figure_color = Color.Red;
            canvas_color = draw_panel.BackColor;
            OffOn = false; 
            DoubleBuffered = true;
            buf = new Bitmap(draw_panel.Width, draw_panel.Height);

            MemoryStream ms = new MemoryStream();
            buf.Save(ms, ImageFormat.Bmp);
            bufByte = ms.ToArray();

            figures = new List<IFigures>();
            all_types = new List<string>();
            assemblyFileNames = new List<string>();

            canvas = draw_panel.CreateGraphics();
            
        }

        private void draw_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (cb_figure.Text != "")
            {

                current_figure_id = cb_figure.Text;
                if (current_object == null)
                    current_object = CreateInstance(GetFigureIndex(current_figure_id));
                current_object.First_point = new Point(e.X, e.Y);
                OffOn = true;                            
            }
        }

        private void draw_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (current_object != null)
            {
                current_object.Last_point = new Point(e.X,e.Y);
                if (OffOn)
                {
                    gbuf = Graphics.FromImage(buf);
                    gbuf.Clear(canvas_color);
                    MemoryStream ms = new MemoryStream();
                    buf.Save(ms, ImageFormat.Bmp);
                    bufByte = ms.ToArray();

                    foreach(IFigures figure in figures)
                        bufByte = figure.Draw(figure_color, canvas_color, bufByte, figures);
                    
                    MemoryStream ms2 = new MemoryStream(current_object.Draw(figure_color, canvas_color, bufByte, figures));
                    Image retBuf = Bitmap.FromStream(ms2);
                    canvas.DrawImageUnscaled(retBuf, 0, 0, buf.Width, buf.Height);
                }
            }
        }

        private void draw_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (current_object != null)
            {
                OffOn = false;

                MemoryStream ms2 = new MemoryStream(current_object.Draw(figure_color, canvas_color, bufByte, figures));
                Image retBuf = Bitmap.FromStream(ms2);
                canvas.DrawImageUnscaled(retBuf, 0, 0, buf.Width, buf.Height);

                figures.Add(current_object);
                all_figures.Add(new figure_frame(GetFigureIndex(current_object.Figure_Name), current_object.First_point, current_object.Last_point));
                current_object = null;
            }
        }

        private int GetFigureIndex(string name)
        {
            int result = 0;
            for (int i = 0; i < new_all_figures.Count; ++i)
            {
                if (new_all_figures[i] == name)
                    result = i;
            }

            return result;
        }

        private IFigures CreateInstance(int index)
        {
            System.Runtime.Remoting.ObjectHandle handle;
            object[] args = {draw_panel};
            handle = domain.CreateInstanceFrom(assemblyFileNames[index],all_types[index] , true, 0, null, args, null, null);
            object obj = handle.Unwrap();
            IFigures figure = (IFigures)obj;
            return figure;
        }

        private void LoadDLL()
        {
            domain = CreateDomain(Directory.GetCurrentDirectory());
            try
            {
                IEnumerable<IFigures> figures = EnumerateFigure(domain);
                foreach (IFigures figure in figures)
                {
                    cb_figure.Items.Add(figure.Figure_Name);
                }

            }
            finally
            {
                //domain = null;
                //GC.Collect(2);
            }
        }

        private IEnumerable<IFigures> EnumerateFigure(AppDomain domain)
        {
            IEnumerable<string> fileNames = Directory.EnumerateFiles(domain.BaseDirectory, "*.dll");
            if (fileNames != null)
            {
                foreach (string assemblyFileName in fileNames)
                {
                    foreach (string typeName in GetTypes(assemblyFileName, typeof(IFigures), domain))
                    {
                        System.Runtime.Remoting.ObjectHandle handle;
                        try
                        {
                            object[] args = { draw_panel };
                            handle = domain.CreateInstanceFrom(assemblyFileName, typeName, true, 0, null, args, null, null);//создание наследника
                        }
                        catch (MissingMethodException)
                        {
                            continue;
                        }

                        object obj = handle.Unwrap();
                        IFigures figure = (IFigures)obj;
                        new_all_figures.Add(figure.Figure_Name);
                        all_types.Add(typeName);
                        assemblyFileNames.Add(assemblyFileName);
                        yield return figure;
                    }
                }
            }
        }

        private IEnumerable<string> GetTypes(string assemblyFileName, Type interfaceFilter, AppDomain domain)
        {
            Assembly asm = domain.Load(AssemblyName.GetAssemblyName(assemblyFileName));
            Type[] types = asm.GetTypes();
            foreach (Type type in types)
            {
                if (type.GetInterface(interfaceFilter.Name) != null)
                {

                    yield return type.FullName;
                }
            }
        }

        private static AppDomain CreateDomain(string path)
        {
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationBase = path;
            return AppDomain.CreateDomain("Temporary domain", null, setup);
        }

        private static void UnloadDomain(AppDomain domain)
        {
            AppDomain.Unload(domain);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadDLL();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnloadDomain(domain);
            domain = null;
            GC.Collect(2);
        }


        private void sm_item_create_Click(object sender, EventArgs e)
        {
            draw_panel.Visible = true;
        }

        private void sm_item_oen_Click(object sender, EventArgs e)
        {
            draw_panel.Visible = true;
            figure_frame figure = new figure_frame(0,new Point(0,0),new Point(0,0));
            byte[] rawdatas = new byte[Marshal.SizeOf(figure)];
            Stream file_stream;
            IntPtr pnt;
            if (open_file.ShowDialog() == DialogResult.OK)
            {
                if ((file_stream = open_file.OpenFile()) != null)
                {
                    figures.Clear();
                    all_figures.Clear();
                    gbuf = Graphics.FromImage(buf);
                    gbuf.Clear(canvas_color);
                    MemoryStream ms = new MemoryStream();
                    buf.Save(ms, ImageFormat.Bmp);
                    bufByte = ms.ToArray();

                    while (file_stream.Read(rawdatas, 0, Marshal.SizeOf(figure)) != 0)//защита от повреждений
                    {
                        pnt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(figure_frame)));
                        Marshal.Copy(rawdatas, 0, pnt, rawdatas.Length);
                        figure = (figure_frame)Marshal.PtrToStructure(pnt, typeof(figure_frame));
                        Marshal.FreeHGlobal(pnt);
                        
                        current_object = CreateInstance(figure.Id);
                        //current_object.Figure_Name = figure.Id;
                        current_object.First_point = figure.First_Point;
                        current_object.Last_point = figure.Last_Point;

                        bufByte = current_object.Draw(figure_color, canvas_color, bufByte, figures);
                        

                        figures.Add(current_object);
                        all_figures.Add(new figure_frame(GetFigureIndex(current_object.Figure_Name), current_object.First_point, current_object.Last_point));
                        current_object = null;
                    }
                    MemoryStream ms2 = new MemoryStream(bufByte);
                    Image retBuf = Bitmap.FromStream(ms2);
                    canvas.DrawImageUnscaled(retBuf, 0, 0, buf.Width, buf.Height);
                    file_stream.Close();
                }
            }

        }

        private void sm_item_save_Click(object sender, EventArgs e)
        {
            figure_frame fig = new figure_frame(0, new Point(0, 0), new Point(0, 0));
            byte[] rawdatas = new byte[Marshal.SizeOf(fig) * all_figures.Count];
            int count = 0;
            if (save_file.ShowDialog() == DialogResult.OK)
            {
                Stream file_stream;
                if ((file_stream = save_file.OpenFile()) != null)
                {
                    foreach (figure_frame figure in all_figures)
                    {
                        IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(figure_frame)));
                        Marshal.StructureToPtr(figure, pnt, false);
                        Marshal.Copy(pnt, rawdatas, count, Marshal.SizeOf(typeof(figure_frame)));
                        Marshal.FreeHGlobal(pnt);
                        count += Marshal.SizeOf(figure);
                    }
                }
                file_stream.Write(rawdatas, 0, Marshal.SizeOf(fig) * all_figures.Count);
                file_stream.Close();
            }

        }


        private void pb_eraser_Click(object sender, EventArgs e)
        {
            Graphics canvas = draw_panel.CreateGraphics();
            gbuf = Graphics.FromImage(buf);
            gbuf.Clear(canvas_color);
            canvas.DrawImageUnscaled(buf, 0, 0, buf.Width, buf.Height);
            figures.Clear();
            all_figures.Clear();
            current_object = null;
        }

        private void bt_change_color_Click(object sender, EventArgs e)
        {
            if (col_dialog.ShowDialog() == DialogResult.OK)
                figure_color = col_dialog.Color;
        }


        
    }
}
