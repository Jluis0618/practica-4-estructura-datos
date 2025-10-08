using System;

namespace MatricesApp
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // para caracteres acentuados en consola

            while (true)
            {
                Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1) Promedio de estudiantes (4x3)");
                Console.WriteLine("2) Matriz dinámica: máximo, mínimo y posiciones");
                Console.WriteLine("0) Salir");
                Console.Write("Opción: ");

                var op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        EjecutarPromedios4x3();
                        break;
                    case "2":
                        EjecutarMatrizDinamica();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }

        private static int LeerEntero(string etiqueta, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write($"{etiqueta}: ");
                string? s = Console.ReadLine();
                if (int.TryParse(s, out int v) && v >= min && v <= max)
                    return v;
                Console.WriteLine("Valor inválido. Intente nuevamente.");
            }
        }

        private static double LeerDouble(string etiqueta, double min = double.MinValue, double max = double.MaxValue)
        {
            while (true)
            {
                Console.Write($"{etiqueta}: ");
                string? s = Console.ReadLine();
                if (double.TryParse(s, System.Globalization.NumberStyles.Float,
                                    System.Globalization.CultureInfo.InvariantCulture, out double v)
                    && v >= min && v <= max)
                    return v;
                Console.WriteLine("Valor inválido. Use punto como separador decimal. Intente nuevamente.");
            }
        }

        private static void EjecutarPromedios4x3()
        {
            Console.WriteLine("\n== PROMEDIO DE ESTUDIANTES (4 estudiantes x 3 asignaturas) ==");
            var gb = new GradeBook(4, 3);
            Console.WriteLine("Ingrese las calificaciones (0 a 100).");
            for (int i = 0; i < gb.Filas; i++)
            {
                for (int j = 0; j < gb.Columnas; j++)
                {
                    gb[i, j] = LeerDouble($"Estudiante {i + 1}, Asignatura {j + 1}", 0, 100);
                }
            }

            Console.WriteLine();
            gb.ImprimirTabla("ASIGNATURAS");

            var promEst = gb.PromediosPorEstudiante();
            var promAsig = gb.PromediosPorAsignatura();

            Console.WriteLine("\nPromedios por estudiante:");
            for (int i = 0; i < promEst.Length; i++)
                Console.WriteLine($"Estudiante {i + 1}: {promEst[i]:0.00}");

            Console.WriteLine("\nPromedios por asignatura:");
            for (int j = 0; j < promAsig.Length; j++)
                Console.WriteLine($"Asignatura {j + 1}: {promAsig[j]:0.00}");
        }

        private static void EjecutarMatrizDinamica()
        {
            Console.WriteLine("\n== MATRIZ DINÁMICA: MÁXIMO, MÍNIMO Y POSICIONES ==");
            int filas = LeerEntero("Número de filas", 1);
            int columnas = LeerEntero("Número de columnas", 1);

            var m = new IntMatrix(filas, columnas);
            Console.WriteLine("Ingrese los valores enteros de la matriz:");
            for (int i = 0; i < m.Filas; i++)
            {
                for (int j = 0; j < m.Columnas; j++)
                {
                    m[i, j] = LeerEntero($"Valor [fila {i + 1}, col {j + 1}]");
                }
            }

            Console.WriteLine();
            m.ImprimirTabla("MATRIZ");

            var (maxVal, maxF, maxC) = m.Maximo();
            var (minVal, minF, minC) = m.Minimo();

            Console.WriteLine("\nResultados:");
            Console.WriteLine($"Mayor: {maxVal} en posición (fila {maxF + 1}, columna {maxC + 1})");
            Console.WriteLine($"Menor: {minVal} en posición (fila {minF + 1}, columna {minC + 1})");
        }
    }
}
