using LIINQ;

class Program
{
    static void Main(string[] args)
    {
        //  se creo  una lista de estudiantes con  5 elementos
        List<Estudiante> estudiantes = new List<Estudiante>
        {
            new Estudiante { Nombre = "Ashly", Edad = 25, Nota = 8.6 },
            new Estudiante { Nombre = "Eduardo", Edad = 17, Nota = 7.5 },
            new Estudiante { Nombre = "lisin", Edad = 23, Nota = 6.9 },
            new Estudiante { Nombre = "Jason", Edad = 20, Nota = 9.8 },
            new Estudiante { Nombre = "Daniel", Edad = 18, Nota = 100 },
        };



    //  se creo un Delegado para filtrar estudiantes
    //filtroEdad y mostrarEstudiantes Juntos, pueden filtrar una lista de estudiantes por edad y mostrar los resultados.
        
        Func<Estudiante, bool> filtroEdad = e => e.Edad > 18;
        Action<List<Estudiante>> mostrarEstudiantes = estudiantes =>
        {
            Console.WriteLine("Estudiantes mayores de 18 años:");
            foreach (var estudiante in estudiantes)
            {
                Console.WriteLine($"Nombre: {estudiante.Nombre}, Edad: {estudiante.Edad}");
            }
        };



        
        // se utilizo un delegado Action<int> llamado MayorEdad
        //que toma un parámetro n de tipo int. La expresión lambda asociada a
        //este delegado verifica si el valor de n es mayor que 18 y, si es así, imprime un mensaje indicando que es mayor de edad.


        Action<int> MayorEdad = n =>
        {
            Boolean ME = (n > 18) ? true : false;

            Console.WriteLine($"Es mayor de edad :");

        };

        MayorEdad(18);




        // se utilizo delegados para realiza dos acciones: encontrar al estudiante con
        //la nota más alta en una lista y ordenar una lista de estudiantes por nombre utilizando expresiones lambda
        Func<IEnumerable<Estudiante>, Estudiante> obtenerNotaMasAlta = estudiantes =>
        {
            return estudiantes.OrderByDescending(e => e.Nota).First();
        };
        
        Estudiante estudianteConNotaMasAlta = obtenerNotaMasAlta(estudiantes);
        Console.WriteLine($"Estudiante con la nota más alta: {estudianteConNotaMasAlta.Nombre} - Nota: {estudianteConNotaMasAlta.Nota}");

        Func<IEnumerable<Estudiante>, IEnumerable<Estudiante>> ordenarPorNombre = estudiantes =>
        {
            return estudiantes.OrderBy(e => e.Nombre);
        };


        // Ordena la lista de estudiantes por nota en orden
        // descendente y devuelve el primer elemento, que es el estudiante con la nota más alta.
        var estudiantesOrdenados = estudiantes.OrderBy(e => e.Nombre);
        Console.WriteLine("Estudiantes ordenados por nombre:");
        foreach (var estudiante in estudiantesOrdenados)
        {
            Console.WriteLine($"Nombre: {estudiante.Nombre}, Edad: {estudiante.Edad}, Nota: {estudiante.Nota}");
        }
        

        // Calcular el promedio de notas de los estudiantes
        var promedioNotas = estudiantes.Average(e => e.Nota);
        Console.WriteLine($"Promedio de notas: {promedioNotas}");
    }
}