using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Figures;

namespace GraphicEditor
{
    class Creator
    {
        public Figure CreateFigure(object sender, string id)
        {
            Figure result = null;
            switch (id)
            {
                case ("Line"):
                    result = new FigureLine(sender);
                    break;
                case ("Rectangle"):
                    result = new FigureRectangle(sender);
                    break;
                case ("Triangle"):
                    result = new FigureTriangle(sender);
                    break;
                case ("Ellipse"):
                    result = new FigureEllipse(sender);
                    break;
                case ("Fill Ellipse"):
                    result = new FigureFillEllipse(sender);
                    break;
            }
            return result;
        }
    }
}
