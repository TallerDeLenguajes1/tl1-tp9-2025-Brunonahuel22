using System.IO;


string patchUsuario;
/*
bool respuesta;

do
{
    Console.Write("Ingrese un directorio valido: ");
    patchUsuario = Console.ReadLine();
    respuesta = Directory.Exists(patchUsuario);
    if (!respuesta)
    {
        Console.WriteLine("El directorio no existe");
    }





} while (!respuesta);

*/

patchUsuario = @"c:\Nueva carpeta";

//Todas las carpetas que se encuentran en ese path

string[] arregloDirectorios = Directory.GetDirectories(patchUsuario);

foreach (var carpetas in arregloDirectorios)
{

    Console.WriteLine(Path.GetFileName(carpetas));
}
// lista para ir guadando cada linea 
List<string> listaParaCVS = new List<string>();

listaParaCVS.Add("Nombre,tamaño,fecha");

//Todos los archivos que se encuentran directamente en esa carpeta
string[] arregloDeArchivos = Directory.GetFiles(patchUsuario);

foreach (var archivos in arregloDeArchivos)
{
    FileInfo archivo = new FileInfo(archivos);

    double tamanioByte = archivo.Length;
    double tamanioKB = tamanioByte / 1024.0;
    string KBenString = tamanioKB.ToString("F2");


    string fechaFormateadaParaCSV = archivo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");



    listaParaCVS.Add($"{archivo.Name},{KBenString},{fechaFormateadaParaCSV}");
}

string nuevaRuta = Path.Combine(patchUsuario, "repostes.cvs");

File.WriteAllLines(nuevaRuta, listaParaCVS);



