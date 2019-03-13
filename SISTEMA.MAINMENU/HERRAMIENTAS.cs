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

namespace SISTEMA.MAINMENU
{
    public class HERRAMIENTAS
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
    }
}
