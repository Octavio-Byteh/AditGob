using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SmartBoard.Models;

namespace SmartBoard.Services
{
    public class ImagesService
    {

        public List<ObrasImagenesMetadata> GetImagenesByNoObra(string NumeroobraExterno)
        {
            List<ObrasImagenesMetadata> lista = new List<ObrasImagenesMetadata>();
            if (!String.IsNullOrWhiteSpace(NumeroobraExterno))
            {
                var pathUpload = Path.Combine(
                          Directory.GetCurrentDirectory(),
                          "wwwroot", "img", "fotos");

                List<String> listaFiles = DirSearch(pathUpload, NumeroobraExterno);

                string mypath = "";
                foreach (string filePath in listaFiles)
                {
                    mypath = filePath.Replace(Path.Combine(
                          Directory.GetCurrentDirectory(),
                          "wwwroot", "img"), "").Replace("/", @"\");
                    lista.Add(new ObrasImagenesMetadata { Pathimagen = mypath });
                }
            }
            return lista;
        }


        public List<ObrasImagenesMetadata> GetImagenesByNoObra(int? Numeroobra)
        {
            List<ObrasImagenesMetadata> lista = new List<ObrasImagenesMetadata>();
            if (Numeroobra.HasValue)
            {
                var pathUpload = Path.Combine(
                          Directory.GetCurrentDirectory(),
                          "wwwroot", "img", "fotos");

                List<String> listaFiles = DirSearch(pathUpload, Numeroobra.Value);

                string mypath = "";
                foreach (string filePath in listaFiles)
                {
                    mypath = filePath.Replace(Path.Combine(
                          Directory.GetCurrentDirectory(),
                          "wwwroot", "img"), "").Replace("/", @"\");
                    lista.Add(new ObrasImagenesMetadata { Pathimagen = mypath });
                }
            }
            return lista;
        }

        private bool HasImageExtension(string source)
        {
            return (source.ToUpper().EndsWith(".PNG") || source.ToUpper().EndsWith(".JPG") || source.ToUpper().EndsWith(".JPEG"));
        }
        private List<String> DirSearch(string sDir, int Numeroobra)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir, "*.*", SearchOption.AllDirectories))
                {
                    if (f.Trim().ToUpper().Contains(@"\" + Numeroobra.ToString() + @"\"))
                    {
                        if (HasImageExtension(f))
                        {
                            files.Add(f);

                        }
                    }
                }
            }
            catch (System.Exception excpt)
            {

            }
            return files;
        }

        private List<String> DirSearch(string sDir, string NumeroobraExterno)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir, "*.*", SearchOption.AllDirectories))
                {
                    if (f.Trim().ToUpper().Contains(@"\" + NumeroobraExterno + @"\"))
                    {
                        if (HasImageExtension(f))
                        {
                            files.Add(f);

                        }
                    }
                }
            }
            catch (System.Exception excpt)
            {

            }
            return files;
        }

    }
}
