// a class to define what an image is
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Image
    {
        public byte Label { get; set; }
        public byte[,] Data { get; set; }
    }
}
