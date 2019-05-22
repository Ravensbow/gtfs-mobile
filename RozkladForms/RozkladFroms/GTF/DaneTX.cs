using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Net;
using System.IO.Compression;


namespace RozkladForms
{
    public class Dane
    {
        public WebClient wc = new WebClient();
        public System.Reflection.Assembly path;
        public string scieszkaGTFS;
        public List<string> pobrane_miasta = new List<string>();
        public List<string> wybrane_miasta = new List<string>();
        public List<string> dostepne_miasta = new List<string>() { "Poznan", "Szczecin", "Wroclaw", "Bydgoszcz" };
        public DirectoryInfo GTFS;
        public Dictionary<string, DirectoryInfo> podfoldery = new Dictionary<string, DirectoryInfo>();
        public Dictionary<string, string> urlMiast = new Dictionary<string, string>() {
            { "Poznan", "https://www.ztm.poznan.pl/pl/dla-deweloperow/getGTFSFile" },
            { "Szczecin", "https://www.zditm.szczecin.pl/rozklady/GTFS/latest/google_gtfs.zip" },
            { "Wroclaw", "https://www.wroclaw.pl/open-data/87b09b32-f076-4475-8ec9-6020ed1f9ac0/OtwartyWroclaw_rozklad_jazdy_GTFS.zip" },
            { "Bydgoszcz","https://mkuran.pl/feed/bydgoszcz/bydgoszcz-latest.zip" } };


        public Dane()
        {
            string gtpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            System.Diagnostics.Debug.WriteLine(gtpath);
            path = Assembly.GetExecutingAssembly();
            
            scieszkaGTFS = gtpath + "/GTFS";
            //Console.WriteLine(scieszkaGTFS);

            if (!Directory.Exists(scieszkaGTFS)) Directory.CreateDirectory(scieszkaGTFS);

            

            GTFS = new DirectoryInfo(scieszkaGTFS);
            System.Diagnostics.Debug.WriteLine(GTFS.FullName);
            foreach (string s in dostepne_miasta)
            {
                podfoldery.Add(s, GTFS.CreateSubdirectory(s));
            }

        }

        public bool SprawdzanieAktualnosci(string s)
        {
            System.Net.WebRequest req = System.Net.HttpWebRequest.Create(urlMiast[s]);
            req.Method = "HEAD";
            System.Net.WebResponse resp = req.GetResponse();

            long ContentLength = 0;
            long internetsize = -1;

            if (long.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
            {
                internetsize = ContentLength;
            }

            long localsize = -1;

            if (File.Exists(GTFS.FullName + "/" + s + "/" + s + "GTFS.zip")) localsize = new FileInfo(GTFS.FullName + "/" + s + "/" + s + "GTFS.zip").Length;

            //Sprawdzanie Aktualizacji:
            if (internetsize != localsize || localsize == -1 || internetsize == -1) { return true; }
            else return false;

        }
        public void PobierzMiasta(string s)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(GTFS.FullName + "/" + s);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            wc.DownloadFile(new System.Uri(urlMiast[s]), GTFS.FullName + "/" + s + "/" + s + "GTFS.zip");

            

            ZipFile.ExtractToDirectory(GTFS.FullName + "/" + s + "/" + s + "GTFS.zip", GTFS.FullName + "/" + s);

            System.Diagnostics.Debug.WriteLine("ELOOOOOOO "+File.Exists(GTFS.FullName + "/" + s + "/" + "agency.txt"));
            


        }
        public void Usuwanie(string s)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(GTFS.FullName + "/" + s);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        public List<string> ListaPobranych()
        {
            List<string> po = new List<string>();

            foreach (string s in dostepne_miasta)
            {


                if (System.IO.File.Exists(GTFS.FullName + "/" + s + "/" + s + "GTFS.zip") && s == "Poznan") { po.Add("Poznan"); }

                if (System.IO.File.Exists(GTFS.FullName + "/" + s + "/" + s + "GTFS.zip") && s == "Wroclaw") { po.Add("Wroclaw"); }


                if (System.IO.File.Exists(GTFS.FullName + "/" + s + "/" + s + "GTFS.zip") && s == "Szczecin") { po.Add("Szczecin"); }


                if (System.IO.File.Exists(GTFS.FullName + "/" + s + "/" + s + "GTFS.zip") && s == "Bydgoszcz") { po.Add("Bydgoszcz"); }

            }

            return po;
        }




        public List<string> PodajMiasta()
        {
            List<string> listawybranych = new List<string>();

            int i = 0;
            Console.WriteLine("Wpisz ciagiem numery interesujacych cie miast:");
            foreach (string s in dostepne_miasta)
            {
                Console.WriteLine(i++ + ". " + s);
            }
            string indeksywybranych = Console.ReadLine();

            foreach (char c in indeksywybranych)
            {

                listawybranych.Add(dostepne_miasta[(Convert.ToInt32(c) - 48)]);
            }

            foreach (string s in listawybranych) { Console.WriteLine(s); }

            return listawybranych;
        }
    }
}