using System;
using System.Collections.Generic;
using System.Linq;

namespace AsignacionAsientos
{
    public class Persona
    {
        public string Nombre { get; set; }
        public int Numero { get; set; }

        public Persona(string nombre, int numero)
        {
            Nombre = nombre;
            Numero = numero;
        }

        public override string ToString()
        {
            return $"#{Numero} - {Nombre}";
        }
    }

    public class Atraccion
    {
        private Queue<Persona> colaEspera;
        private int capacidadMaxima = 30;

        public Atraccion()
        {
            colaEspera = new Queue<Persona>();
        }

        public void AgregarPersona(Persona persona)
        {
            if (colaEspera.Count < capacidadMaxima)
            {
                colaEspera.Enqueue(persona);
                Console.WriteLine($"Agregado: {persona}");
            }
            else
            {
                Console.WriteLine($"[!] No se pudo agregar a {persona.Nombre}. La atracción está llena.");
            }
        }

        public void MostrarCola()
        {
            Console.WriteLine("\nCola de espera actual:");
            if (colaEspera.Count == 0)
            {
                Console.WriteLine("La cola está vacía.");
                return;
            }
            foreach (var persona in colaEspera)
            {
                Console.WriteLine(persona);
            }
        }

        public void ConsultarPorNombre(string nombre)
        {
            var persona = colaEspera.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (persona != null)
                Console.WriteLine($"Se encontró en la cola: {persona}");
            else
                Console.WriteLine($"No se encontró a '{nombre}' en la cola.");
        }

        public void ConsultarPorNumero(int numero)
        {
            var persona = colaEspera.FirstOrDefault(p => p.Numero == numero);
            if (persona != null)
                Console.WriteLine($"Se encontró en la cola: {persona}");
            else
                Console.WriteLine($"No se encontró el número #{numero} en la cola.");
        }

        public void MostrarSiguiente()
        {
            if (colaEspera.Count == 0)
                Console.WriteLine("La cola está vacía.");
            else
                Console.WriteLine($"Siguiente en la cola: {colaEspera.Peek()}");
        }

        public void MostrarCantidad()
        {
            Console.WriteLine($"Cantidad de personas en cola: {colaEspera.Count}");
        }

        public void ProcesarSubida()
        {
            Console.WriteLine("\nProcesando acceso a la atracción...\n");
            while (colaEspera.Count > 0)
            {
                var persona = colaEspera.Dequeue();
                Console.WriteLine($"{persona} ha subido a la atracción.");
            }

            Console.WriteLine("\nTodos los asientos han sido ocupados.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Atraccion atraccion = new Atraccion();

            Console.WriteLine("Asignación de Asientos para la Atracción (Capacidad: 30 personas)\n");

            // Simula la llegada de 30 personas
            for (int i = 1; i <= 30; i++)
            {
                string nombre = $"Persona_{i}";
                atraccion.AgregarPersona(new Persona(nombre, i));
            }

            atraccion.MostrarCola();
            atraccion.MostrarCantidad();
            atraccion.MostrarSiguiente();

            Console.WriteLine("\nConsulta por nombre: Persona_15");
            atraccion.ConsultarPorNombre("Persona_15");

            Console.WriteLine("\nConsulta por número: 20");
            atraccion.ConsultarPorNumero(20);

            // Procesar la subida a la atracción
            atraccion.ProcesarSubida();

            Console.WriteLine("\nFin del proceso. Presiona cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}

