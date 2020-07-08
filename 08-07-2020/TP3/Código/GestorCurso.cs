using System;
using System.Collections.Generic;

namespace Código
{
    // CLASE GESTOR DE CURSOS

    class GestorCursos
    {
        // FUNCIÓN PRINCIPAL

        static void Main (string[] args)
        {
            Console.WriteLine ("¡Bienvenido nuevamente! ¿En qué puedo ayudarlo?");

            while (true)
            {
                var finalizado = DictadoCursos ();

                if (finalizado) break;
            }
        }

        // FUNCIÓN DICTADO CURSOS

        static public bool DictadoCursos ()
        {
            while (true)
            {
                Console.WriteLine("\n 1. Registro Participante"); 
                Console.WriteLine("\n 2. Registro Curso");
                Console.WriteLine("\n 3. Muestreo Cursos");
                Console.WriteLine("\n 4. Muestreo Inscriptos");
                Console.WriteLine("\n 5. Muestreo Inscripciones");
                
                Console.WriteLine("\n¿Qué desea realizar?");

                var Opcion = int.Parse (Console.ReadLine ());

                switch (Opcion)
                {
                    case 1:
                        
                        Participante.RegistroNuevoParticipante ();
                        
                        break;

                    case 2:
                        
                        Curso.RegistroNuevoCurso ();
                        
                        break;

                    case 3:
                        
                        Curso.MuestreoCursos ();
                        
                        break;

                    case 4:
                        
                        Participante.MuestreoParticipantes ();
                        
                        break;

                    case 5:
                        
                        Inscripcion.MuestreoInscripciones ();
                        
                        break;

                    default:
                        
                        Console.WriteLine ("No válido");
                        
                        break;
                }

                Console.Clear ();
                
                Console.WriteLine ("\n¿Desea seguir trabajando? \n1. Sí \n2. No");
                
                var opcionElegida = int.Parse (Console.ReadLine ());
                
                Console.Clear ();

                if (opcionElegida == 1) 
                {
                    return false;
                }

                else 
                {
                    return true;
                }
            }
        }

        // CLASE CURSO

        class Curso
        {
            // ATRIBUTOS CORRESPONDIENTES

            public static List<Curso> Cursos = new List<Curso> ();
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public string Horario { get; set; }
            public string Aula { get; set; }
            public double CupoMaximo { get; set; }
            public double CupoMinimo { get; set; }

            // FUNCIÓN CURSO

            public Curso (string denominacion, string descripcion, DateTime fechaInicio, DateTime fechaFin, string horario, string aula, double cupomax, double cupomin)
            {
                Nombre = denominacion;
                Descripcion = descripcion;
                
                FechaInicio = fechaInicio;
                FechaFin = fechaFin;
                
                Horario = horario;
                
                Aula = aula;
                
                CupoMaximo = cupomax;
                CupoMinimo = cupomin;
            }

            // CLASE REGISTRO NUEVO CURSO

            static public void RegistroNuevoCurso ()
            {
                Console.WriteLine ("Nombre: ");

                string nombre = Console.ReadLine ();

                Console.WriteLine ("Descripción: ");
                string descripcion = Console.ReadLine ();

                Console.WriteLine ("Fecha Inicio: ");
                DateTime fechaInicio = DateTime.Parse (Console.ReadLine ());

                Console.WriteLine ("Fecha Fin: ");
                DateTime fechaFin = DateTime.Parse (Console.ReadLine ());

                Console.WriteLine ("Horario: ");
                string horario = Console.ReadLine ();

                Console.WriteLine ("Aula: ");
                string aula = Console.ReadLine ();

                Console.WriteLine ("Cupo Mínimo: ");
                double cupomax = double.Parse (Console.ReadLine ());

                Console.WriteLine("Cupo Máximo: ");
                double cupomin = double.Parse (Console.ReadLine ());
            }

            // FUNCIÓN MUESTREO CURSOS DISPONIBLES

            static public void MuestreoCursos ()
            {
                int pos = 1;
                foreach (var cursos in Cursos)
                {
                    Console.WriteLine ("\n Nombre: " + cursos.Nombre);
                    Console.WriteLine ("\n Descripción: " + cursos.Descripcion);
                    Console.WriteLine ("\n Fecha Inicio: " + cursos.FechaInicio);
                    Console.WriteLine ("\n Fecha Fin: " + cursos.FechaFin);
                    Console.WriteLine ("\n Horario: " + cursos.Horario);
                    Console.WriteLine ("\n Aula: " + cursos.Aula);
                    Console.WriteLine ("\n Cupo Mínimo: " + cursos.CupoMinimo);
                    Console.WriteLine ("\n Cupo Máximo: " + cursos.CupoMaximo);

                    pos++;
                }

                RegistroNuevoDocente.MuestreoDocentes ();
            }
        }

        // CLASE DOCENTE
        class Docente
        {
            // ATRIBUTOS CORRESPONDIENTES

            public string NombreDocente { get; set; }
            public string DNIDocente { get; set; }
            public string EmailDocente { get; set; }
            public string TelefonoDocente { get; set; }
            public string EspecialidadDocente { get; set; }

            // FUNCIÓN DOCENTE

            public Docente (string nombre, string dni, string email, string telefono, string especialidadDocente)
            {
                NombreDocente = nombre;
                DNIDocente = dni;
                EmailDocente = email;
                TelefonoDocente = telefono;
                EspecialidadDocente = especialidadDocente;
            }
        }

        // CLASE REGISTRO NUEVO DOCENTE
        public class RegistroNuevoDocente
        {
            static List<Docente> Docentes = new List <Docente> ();

            // FUNCIÓN REGISTRO NUEVO DOCENTE
        
            static RegistroNuevoDocente ()
            {
                Docentes.Add (new Docente ("Analia Fava", "12345678", "analiafava@gmail.com", "3564565988", "Ing. Química"));
                Docentes.Add (new Docente ("Eduardo Massoni", "12345679", "eduardomassoni@gmail.com", "3564617071", "Ing. en Sistemas"));
                Docentes.Add (new Docente ("Manuel Luques", "12345671", "manuelluques@gmail.com", "3564123456", "Ing. Electrónica"));
                Docentes.Add (new Docente ("Ignacio Massoni", "12345672", "nachomassoni@gmail.com", "3564506065", "Ing. Electromecánica"));
                Docentes.Add (new Docente ("Carlos Escudero", "12345673", "charlyescudero@gmail.com", "3564606570", "Ing. Industrial"));
            }

            // FUNCIÓN MUESTREO DOCENTES

            static public void MuestreoDocentes ()
            {
                int pos = 1;

                foreach (var docentes in Docentes)
                {
                    Console.WriteLine (pos + "." + "\n" + "Nombre: " +  docentes.NombreDocente + "\n" + "DNI: " + docentes.DNIDocente + "\n" + "Email: " + docentes.EmailDocente + "\n" + "Teléfono: " + docentes.TelefonoDocente + "\n" + "Carrera: " + docentes.EspecialidadDocente);
                    
                    pos++;
                }
            }
        }

        // CLASE PARTICIPANTE

        class Participante
        {
            // ATRIBUTOS CORRESPONDIENTES

            public static List <Participante> Participantes = new List <Participante> ();
            public string Nombre { get; set; }
            public string DNI { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }

            // FUNCIÓN PARTICIPANTE

            public Participante (string nombre, string dni, string email, string telefono)
            {
                Nombre = nombre;
                DNI = dni;
                Email = email;
                Telefono = telefono;
            }

            // FUNCIÓN REGISTRO NUEVO PARTICIPANTE

            static public void RegistroNuevoParticipante ()
            {
                Console.WriteLine ("\nNombre: ");
                string nombre = Console.ReadLine ();

                Console.WriteLine ("\nDNI: ");
                string dni = Console.ReadLine ();

                Console.WriteLine ("\nEmail: ");
                string email = Console.ReadLine ();

                Console.WriteLine ("\nTeléfono: ");
                string telefono = Console.ReadLine ();
            }
            
            // FUNCIÓN MUESTREO PARTCIPANTES

            static public void MuestreoParticipantes ()
            {
                int pos = 1;

                foreach (var participante in Participantes)
                {
                    Console.WriteLine (pos + "." + "\n" + "Nombre Completo: " +  participante.Nombre + "\n" + "Email: " + participante.Email + "\n");
                    
                    pos++;
                }
            }
        }

        // CLASE INSCRIPCIÓN

        class Inscripcion
        {   
            // ATRIBUTOS CORRESPONDIENTES

            public static List <Inscripcion> Inscripciones = new List <Inscripcion> ();
            public DateTime FechaInscripcion { get; set; }
            public Curso Curso { get; set; }
            public Participante Participante { get; set; }

            // FUNCIÓN INSCRIPCIÓN
            
            public Inscripcion (Participante participante, DateTime fechainscripcion, Curso curso)
            {
                Participante = participante;
                FechaInscripcion = fechainscripcion;
                Curso = curso;
            }

            // FUNCIÓN MUESTREO INSCRIPCIONES

            static public void MuestreoInscripciones ()
            {
                foreach (var inscripciones in Inscripciones)
                {
                    Console.WriteLine ("\n Fecha Inscripcion: " + inscripciones.FechaInscripcion);
                    Console.WriteLine ("\n Nombre Curso: " + inscripciones.Curso.Nombre);
                    Console.WriteLine ("\n Fecha Inicio: " + inscripciones.Curso.FechaInicio);
                    Console.WriteLine ("\n Nombre Persona: " + inscripciones.Participante.Nombre);
                    Console.WriteLine ("\n Telefono: " + inscripciones.Participante.Telefono);
                }
            }
        }
    }
}