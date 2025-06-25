using System.IO;
using System.Text;

string direccion = @"c:\Users\Estudiante\Desktop\tl1-tp9-2025-Brunonahuel22\LectorTagMP3";
string archivo = @"prueba.mp3";

string directorio = Path.Combine(direccion, archivo);

using var archivomp3 = new FileStream(directorio, FileMode.Open);
using var br = new BinaryReader(archivomp3);

archivomp3.Seek(-128, SeekOrigin.End);

byte[] arreglobyte = br.ReadBytes(128);

string tag = Encoding.GetEncoding("latin1").GetString(arreglobyte, 0, 3).TrimEnd('\0');
Console.WriteLine($"El tag es: {tag}");

string titulo = Encoding.GetEncoding("latin1").GetString(arreglobyte, 3, 30).TrimEnd('\0');
string artista = Encoding.GetEncoding("latin1").GetString(arreglobyte, 33, 30).TrimEnd('\0');
string album = Encoding.GetEncoding("latin1").GetString(arreglobyte, 63, 30).TrimEnd('\0');
string anio = Encoding.GetEncoding("latin1").GetString(arreglobyte, 93, 4).TrimEnd('\0');

Console.WriteLine($"Título: {titulo}");
Console.WriteLine($"Artista: {artista}");
Console.WriteLine($"Álbum: {album}");
Console.WriteLine($"Año: {anio}");






