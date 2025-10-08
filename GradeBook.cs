using System;

namespace MatricesApp
{
    public class GradeBook
    {
        private readonly double[,] _notas;

        public int Filas { get; }
        public int Columnas { get; }

        public GradeBook(int filas, int columnas)
        {
            if (filas <= 0 || columnas <= 0) throw new ArgumentException("Dimensiones inválidas.");
            Filas = filas;
            Columnas = columnas;
            _notas = new double[filas, columnas];
        }

        public double this[int fila, int col]
        {
            get => _notas[fila, col];
            set => _notas[fila, col] = value;
        }

        public void ImprimirTabla(string titulo)
        {
            Console.WriteLine($"== {titulo} ==");
            // Encabezado
            Console.Write("            ");
            for (int j = 0; j < Columnas; j++)
                Console.Write($"Asign {j + 1,10}");
            Console.WriteLine();
            Console.WriteLine(new string('-', 12 + Columnas * 10));

            for (int i = 0; i < Filas; i++)
            {
                Console.Write($"Est {i + 1,6} |");
                for (int j = 0; j < Columnas; j++)
                    Console.Write($"{_notas[i, j],10:0.00}");
                Console.WriteLine();
            }
        }

        public double[] PromediosPorEstudiante()
        {
            var r = new double[Filas];
            for (int i = 0; i < Filas; i++)
            {
                double suma = 0;
                for (int j = 0; j < Columnas; j++) suma += _notas[i, j];
                r[i] = suma / Columnas;
            }
            return r;
        }

        public double[] PromediosPorAsignatura()
        {
            var r = new double[Columnas];
            for (int j = 0; j < Columnas; j++)
            {
                double suma = 0;
                for (int i = 0; i < Filas; i++) suma += _notas[i, j];
                r[j] = suma / Filas;
            }
            return r;
        }
    }
}
