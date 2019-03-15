using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections;

namespace SISTEMA.TATTOO
{
   public class Herramientas
    {
        #region ENCODE IMAGEN
        public static string encodeImagen(string nombreArchivo)
        {
            Bitmap image = (Bitmap)Image.FromFile(nombreArchivo);
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();

                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        #endregion

        #region DECODE IMAGEN
        public static Image decodeImagen(string sBase64, string Ext)
        {
            byte[] imageBytes = Convert.FromBase64String(sBase64);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
        #endregion
    }
}
