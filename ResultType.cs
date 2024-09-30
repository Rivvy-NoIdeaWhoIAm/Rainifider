using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainifider
{
    public partial class ResultType
    {
#pragma warning disable
        public class Error : ResultType
        {
            public Color CodeColor { get; init; }
            public Point TextPosition { get; init; }
            public string message { get; init; }
            
            public Error(string message, Point TextPosition, int? page)
            {
                this.message = message;
                this.TextPosition = TextPosition;
                this.CodeColor = Color.Red;
                
            }
            public Error(string message, Point TextPosition)
            {
                this.message = message;
                this.TextPosition = TextPosition;
                this.CodeColor = Color.Red;
            }
        }
        public class Debug : ResultType
        {
            public Color CodeColor { get; }
            public Point TextPosition { get; init; }
            public string message { get; init; }
            
            public Debug(string message, Point TextPosition, int? page)
            {
                this.message = message;
                this.TextPosition = TextPosition;
                this.CodeColor = Color.Yellow;
                
            }
            public Debug(string message, Point TextPosition)
            {
                this.message = message;
                this.TextPosition = TextPosition;
                this.CodeColor = Color.Yellow;
            }
        }
        public class Message : ResultType
        {
            public Color CodeColor { get; }
            public Point TextPosition { get; init; }
            public string message { get; init; }
            
            public Message(string message, Point TextPosition, int? page)
            {
                this.message = message;
                this.TextPosition = TextPosition;
                this.CodeColor = Color.Black;
                
            }
            public Message(string message, Point TextPosition)
            {
                this.message = message;
                this.TextPosition = TextPosition;
                this.CodeColor = Color.Black;
            }
        }
        public class Success : ResultType
        {
            public Color CodeColor { get; }
            public Point TextPosition { get; init; }
            public string message { get; init; }
            
            public Success(string message, Point TextPosition, int? page)
            {
                this.message = message;
                this.TextPosition = TextPosition;
                this.CodeColor = Color.Green;
                
            }
            public Success(string message, Point TextPosition)
            {
                this.message = message;
                this.TextPosition = TextPosition;
                this.CodeColor = Color.Green;
            }
        }
        public class Warning : ResultType
        {
            public Color CodeColor { get; }
            public Point TextPosition { get; init; }
            public string message { get; init; }
            
            public Warning(string message, Point TextPosition, int? page)
            {
                this.message = message;
                this.TextPosition = TextPosition;
                this.CodeColor = Color.Yellow;
                
            }
            public Warning(string message, Point TextPosition)
            {
                this.message = message;
                this.TextPosition = TextPosition;
                this.CodeColor = Color.Yellow;
            }
        }
    }
}
