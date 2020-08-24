/* La secretaría de extensión y cultura de la Facultad ofrece cursos a los alumnos, docentes y a la
comunidad en general.
Existe una nómina de cursos que se dictan cada año, por ejemplo, el curso "Excel para
empresas" se dicta durante el primer cuatrimestre.
Cada curso tiene un nombre, una descripción que explica a quién está destinado, si hay un
docente que lo dicta habitualmente también se registra esa información.
Se pueden agregar cursos nuevos ya sea por propuesta de algún docente que quiera dictarlo,
por propuesta de algún departamento de carrera o bien por decisión de la propia secretaria.
Cada año se programan los cursos a dictar, en ese momento se define horario y fechas de
dictado del curso, el docente, el aula, cupo mínimo de alumnos, cupo máximo de alumnos y
fecha límite de inscripción.
Cuando una persona se inscribe a un curso se registra su nombre y apellido, DNI, email y
teléfono. 

a) Puede ocurrir que un curso tenga más de un docente.
b) Puede ocurrir que quien dicte el curso no esté disponible por alguna razón, en ese caso
se debe buscar un nuevo docente.
c) Puedo ocurrir que un curso de deba cancelar por falta de inscriptos. */

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TP3_Nuevo
{
    class GestionCursos
    {
        static RegistroCursos RegistroCursos = new RegistroCursos();
        static RegistroProfesores RegistroProfesores = new RegistroProfesores();
        static RegistroAlumnos RegistroAlumnos = new RegistroAlumnos();
        static RegistroDictadoCursos RegistroDictadoCursos = new RegistroDictadoCursos();
        static RegistroInscripciones RegistroInscripciones = new RegistroInscripciones();

        static void Main (string [] args)
        {
            while (true)
            {
                var finalizado = Operando ();

                if (finalizado)
                {
                    break;
                }
            }
        }

        static bool Operando()
        {
            Console.WriteLine ("\n1. Creación Curso");
            Console.WriteLine ("\n2. Dictado Curso");
            Console.WriteLine ("\n3. Inscripción Alumno a Curso");
            Console.WriteLine ("\n4. Cancelación Curso");

            string opcionMenu = Console.ReadLine ();
            
            Console.Clear ();

            switch (int.Parse (opcionMenu))
            {
                case 1:
                {
                    CrearUnCurso ();

                    break;
                }

                case 2:
                {
                    AbrirDictadoCurso();

                    break;
                }
                
                case 3:
                {
                    InscribirAlumno ();

                    break;
                }

                case 4:
                {
                    CancelarCurso ();

                    break;
                }

                default:
                {
                    Console.WriteLine ("\nLa opción ingresada no es válida");
                    Console.WriteLine ("\nPresione una tecla para continuar");
                    
                    Console.ReadKey ();

                    break;  
                }
            }

            var continuar = MostrarMenuContinuar ();

            return continuar;
        }

        static bool MostrarMenuContinuar ()
        {
            Console.Clear ();
            
            Console.WriteLine ("\n¿Desea seguir?   \n1.Sí \n2.No");
            
            var opcionOperar = int.Parse (Console.ReadLine ());
            
            Console.Clear ();
            
            if (opcionOperar == 1) 
            {
                return false;
            }

            else 
            {
                return true;
            }
        }

        static void CrearUnCurso ()
        {
            Console.WriteLine ("\nNombre del Curso: ");

            var nombre = Console.ReadLine ();

            Console.WriteLine ("\nDescripción del Curso: ");
            
            var descripcion = Console.ReadLine ();

            Console.Clear ();

            var curso = new Curso (nombre, descripcion);

            curso.MostrarCurso ();

            Console.WriteLine (" \n ¿Guardar? \n1.Si \n2.No");

            var guardar = int.Parse (Console.ReadLine ());
            
            if (guardar == 1) 
            {
                RegistroCursos.AgregarCurso (curso);
            }

            Console.Clear ();
            
            Console.WriteLine ("\n¡Curso guardado exitosamente!");
        }

        static void AbrirDictadoCurso ()
        {
            RegistroCursos.MostrarCursos ();

            Console.WriteLine ("\nCurso: ");
            
            var cursoIndice = int.Parse (Console.ReadLine ()) - 1;
            
            Curso curso = RegistroCursos.ObtenerCurso (cursoIndice);
            
            Console.Clear ();

            Console.WriteLine ("\nNúmero de Aula: ");
            
            var aula = int.Parse (Console.ReadLine ());
            
            Console.Clear ();

            Console.WriteLine ("\nFecha límite de inscripción (dd/MM/yyyy): ");

            var fechaLimiteString = Console.ReadLine ();
            
            var fechaLimite = DateTime.ParseExact (fechaLimiteString, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            
            Console.Clear ();

            Console.WriteLine ("\nCupo máximo: ");

            var cupoMax = int.Parse (Console.ReadLine ());
            
            Console.Clear ();

            Console.WriteLine ("\nCupo mínimo: ");
            
            var cupoMin = int.Parse (Console.ReadLine ());
            
            Console.Clear ();

            var dictadoCurso = new DictadoCurso (curso, aula, fechaLimite, cupoMax, cupoMin);

            dictadoCurso.AgregarHorarios ();
            
            Console.Clear();

            bool seguirAgregandoProfesores = false;

            do
            {
                RegistroProfesores.MostrarProfesores ();
                
                Console.WriteLine ("\nProfesor: ");
                
                var profesorIndice = int.Parse (Console.ReadLine ()) - 1;
                
                Profesor profesor = RegistroProfesores.ObtenerProfesor (profesorIndice);
                
                Console.Clear ();

                dictadoCurso.AgregarProfesor (profesor);

                Console.WriteLine ("\n¿Desea agregar otro profesor?   \n1.Si \n2.No");

                var seguir = int.Parse (Console.ReadLine ());
                
                if (seguir == 1) 
                {
                    seguirAgregandoProfesores = true;
                }

            } while (seguirAgregandoProfesores);

            Console.Clear ();

            dictadoCurso.MostrarDictadoCurso ();

            Console.WriteLine ("\n¿Guardar?     \n1.Si \n2.No");

            var guardar = int.Parse (Console.ReadLine ());

            if (guardar == 1) 
            {
                RegistroDictadoCursos.AgregarDictadoCurso (dictadoCurso);
            }
        }

        static void InscribirAlumno ()
        {
            bool existenCursosVigentes = RegistroDictadoCursos.VerificarCursosVigentes ();

            if (!existenCursosVigentes)
            {
                Console.WriteLine ("\nNo hay cursos vigentes");
                Console.WriteLine ("\nPresione una tecla para continuar");
                
                Console.ReadKey ();
                
                return;
            }

            Alumno alumno = buscarAlumno ();
            
            Console.Clear ();

            Console.WriteLine ("\nCursos vigentes: ");
            
            RegistroDictadoCursos.MostarCursosVigentes ();
            
            Console.WriteLine ("\nElección de Curso: ");
            
            var cursoIndice = int.Parse (Console.ReadLine ()) - 1;
            
            DictadoCurso dictadoCurso = RegistroDictadoCursos.ObtenerCursoDictado (cursoIndice);
            
            Console.Clear ();

            var inscripcion = new Inscripcion ();
            
            inscripcion.Alumno = alumno;
            
            inscripcion.DictadoCurso = dictadoCurso;
            
            inscripcion.MostrarInscripcion ();

            Console.WriteLine ("\n¿Guardar?     \n1.Si\n2.No");
            
            var guardar = int.Parse (Console.ReadLine ());
            
            if (guardar == 1) 
            {
                RegistroInscripciones.AgregarInscripcion (inscripcion);
            }

            Console.Clear ();
        }

        static Alumno buscarAlumno ()
        {
            Console.WriteLine ("\n1. Registro de Nuevo Alumno");
            
            Console.WriteLine ("\n2. Elección de Alumno Existente");
            
            var opcionMenu = int.Parse (Console.ReadLine ());

            if (opcionMenu == 1)
            {
                Console.WriteLine ("\nNombre: ");
                
                string nombre = Console.ReadLine ();
                
                Console.Clear ();

                Console.WriteLine ("\nApellido: ");
                
                string apellido = Console.ReadLine ();
                
                Console.Clear ();

                Console.WriteLine ("\nDNI: ");
                
                double dni = double.Parse (Console.ReadLine ());
                
                Console.Clear ();

                Console.WriteLine ("\nE-mail: ");
                
                string email = Console.ReadLine ();
                
                Console.Clear ();

                Console.WriteLine ("\nTeléfono: ");
                
                double telefono = double.Parse (Console.ReadLine ());
                
                Console.Clear ();

                Alumno alumno = new Alumno (nombre, apellido, dni, email, telefono);

                RegistroAlumnos.AgregarAlumno (alumno);

                return alumno;
            }

            else
            {
                Console.Clear ();
                
                Console.WriteLine ("\nAlumnos: ");
                
                RegistroAlumnos.MostrarAlumnos ();
                
                Console.WriteLine ("\nElección Alumno: ");
                
                var alumnoIndice = int.Parse (Console.ReadLine ()) - 1;
                
                Alumno alumno = RegistroAlumnos.ObtenerAlumno (alumnoIndice);
                
                return alumno;
            }
        }

        static void CancelarCurso ()
        {
            var cursosVigentes = RegistroDictadoCursos.VerificarCursosVigentes ();

            if (!cursosVigentes)
            {
                Console.WriteLine ("\nNo hay cursos vigentes");
                Console.WriteLine ("\nPresione una tecla para continuar");
                
                Console.ReadKey ();
                
                return;
            }

            Console.WriteLine ("\nCursos Vigentes: ");
            
            RegistroDictadoCursos.MostarCursosVigentes ();

            Console.WriteLine ("\nCurso a cancelar: ");
            
            var cursoIndice = int.Parse (Console.ReadLine ()) - 1;
            
            RegistroDictadoCursos.CancelarCurso (cursoIndice); 

            Console.WriteLine ("\nCancelado exitósamente");
        }
    }

    public class Alumno 
    {
        public string Nombre {get;}
        public string Apellido {get; } 
        public double Dni {get;}
        public string Email {get;}
        public double Telefono {get;}

        public Alumno (string nombre, string apellido, double dni, string email, double telefono)
        {
            Nombre = nombre;
            Apellido = apellido; 
            Dni= dni; 
            Email = email; 
            Telefono = telefono;
        }
        
        public void MostrarAlumno ()
        {
            Console.WriteLine ($"\n{Apellido}, {Nombre} ({Dni})"); 
            Console.WriteLine ($"\nTeléfono:{Telefono.ToString()} E-mail: {Email}");
        }
    }    

    public class Curso
    {
        public string Nombre { get; }
        public string Descripcion { get; }

        public Curso (string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
        
        public void MostrarCurso ()
        {
            Console.WriteLine ($"\nCurso: {Nombre}");
            Console.WriteLine ($"\n{Descripcion}");
        }
    }

    public class DictadoCurso
    {
        public Curso Curso { get; }
        public List<HorarioCurso> HorariosCurso { get; }
        public int AulaId { get; }
        public DateTime FechaLimiteInscripcion { get; }
        public int CupoMinimo { get; }
        public int CupoMaximo { get; }
        public bool Vigente { get; set; }
        public List<Profesor> Profesores { get; set; }

        public DictadoCurso (Curso curso, int aulaId, DateTime fechaLimiteInscripcion, int cupoMaximo, int cupoMinimo)
        {
            HorariosCurso = new List<HorarioCurso> ();
            AulaId = aulaId;
            FechaLimiteInscripcion = fechaLimiteInscripcion;
            CupoMaximo = cupoMaximo;
            CupoMinimo = cupoMinimo;
            Curso = curso;
            Profesores = new List<Profesor> ();
            Vigente = true;
        }
        
        public void MostrarDictadoCurso ()
        {
            Curso.MostrarCurso ();
            
            Console.WriteLine ($"\nCupo mínimo: {CupoMinimo} Cupo máximo: {CupoMaximo} Aula: {AulaId} ");
            
            Console.WriteLine ($"\nLímite inscripcion: {FechaLimiteInscripcion.ToShortDateString ()} ");

            Console.WriteLine ("\nHorarios: ");

            foreach (HorarioCurso horarioCurso in HorariosCurso)
            {
                horarioCurso.MostrarHorarioCurso ();
            }

            Console.WriteLine ("\nProfesores: ");

            foreach (Profesor profesor in Profesores)
            {
                profesor.MostarProfesor (); 
            }
        }

        public void CancelarCurso () 
        {
            Vigente = false;
        }

        public void AgregarProfesor (Profesor profesor)
        {
            Profesores.Add (profesor);
        }

        public void AgregarHorarios ()
        {
            string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };

            var seguirAgregandoHorarios = false;

            do
            {
                Console.WriteLine ("Seleccione el día: ");

                for (int i = 0; i < dias.Length; i++)
                {
                    Console.Write ((i + 1).ToString () + ". ");
                    
                    Console.WriteLine (dias [i]);
                }

                var diaIndice = int.Parse(Console.ReadLine ());
                
                string dia = dias [diaIndice];
                
                Console.Clear ();

                Console.WriteLine ("\nIngrese hora de comienzo del curso (HH:mm) : ");
                
                var horaInicioString = Console.ReadLine ();
                
                var horaInicio = DateTime.ParseExact (horaInicioString, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                Console.WriteLine ("\nIngrese hora de fin del curso (HH:mm) : ");
                
                var horaFinString = Console.ReadLine ();
                
                var horaFin = DateTime.ParseExact (horaFinString, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                Console.Clear ();

                var horarioCurso = new HorarioCurso (dia, horaInicio, horaFin);

                horarioCurso.MostrarHorarioCurso ();
                
                Console.WriteLine ("\n¿Guardar? \n1.Si \n2.No");

                var guardar = int.Parse (Console.ReadLine ());
                
                if (guardar == 1) 
                {
                    HorariosCurso.Add (horarioCurso);
                }

                Console.Clear ();

                Console.WriteLine ("\n¿Desea agregar otro horario? \n1.Si \n2.No");

                var seguir = int.Parse (Console.ReadLine ());
                
                if (seguir == 1) 
                {
                    seguirAgregandoHorarios = true;
                }

                Console.Clear ();

            } while (seguirAgregandoHorarios); 
        }
    }

    public class HorarioCurso
    {
        public string Dia { get; }
        public DateTime HoraInicio { get; }
        public DateTime HoraFin { get; }
        
        public HorarioCurso (string dia, DateTime horaInicio, DateTime horaFin)
        {
            HoraInicio = horaInicio;
            HoraFin = horaFin;
            Dia = dia;
        }

        public void MostrarHorarioCurso ()
        {
            Console.WriteLine ($"\nDía: {Dia} Horario: {HoraInicio.ToString("HH:mm")} - {HoraFin.ToString("HH:mm")}");
        }
    }

    public class Inscripcion
    {
        public Alumno Alumno { get; set;  }
        public DictadoCurso DictadoCurso { get; set; }

        public void MostrarInscripcion ()
        { 
            DictadoCurso.MostrarDictadoCurso (); 
            
            Console.WriteLine ("\nInscripto:");
            
            Alumno.MostrarAlumno (); 
        }
    }

    public class Profesor
    {
        public string Nombre { get; }
        public string Apellido { get; }
        public double Telefono { get; }
        public double Dni { get; }
        public string Email { get; }

        public Profesor (string nombre, string apellido, double telefono, double dni, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Dni = dni;
            Email = email;
        }

        public void MostarProfesor ()
        {
            Console.WriteLine ($"\nProfesor: {Apellido}, {Nombre} ({Dni})"); 
            
            Console.WriteLine ($"\nTeléfono: {Telefono} E-mail: {Email}");
        }
    }

    public class RegistroAlumnos 
    {
        public void AgregarAlumno (Alumno alumno) 
        {
            var db = GestorBD.ObtenerRegistros ();
            
            db.Alumnos.Add (alumno);
            
            GestorBD.SobrescribirRegistros (db);
        }

        public void MostrarAlumnos () 
        {
            var db = GestorBD.ObtenerRegistros ();
            
            for (int i = 0; i < db.Alumnos.Count; i++) 
            {
                Console.Write ("\n" + (i + 1).ToString () + ". ");
            
                db.Alumnos [i].MostrarAlumno ();
            }
        }

        public Alumno ObtenerAlumno (int index ) 
        {
            var db = GestorBD.ObtenerRegistros ();
            
            return db.Alumnos [index]; 
        }
    }

    public class RegistroCursos 
    {
        public void AgregarCurso (Curso curso) 
        {
            var db = GestorBD.ObtenerRegistros ();
            
            db.Cursos.Add (curso);
            
            GestorBD.SobrescribirRegistros (db);
        }

        public void MostrarCursos () 
        {
            var db = GestorBD.ObtenerRegistros ();
            
            for (int i = 0; i < db.Cursos.Count; i++) 
            {
                Console.Write ("\n" + (i + 1).ToString () + ". ");
            
                db.Cursos [i].MostrarCurso ();
            }
        }

        public Curso ObtenerCurso (int index) 
        {
            var db = GestorBD.ObtenerRegistros ();
            
            return db.Cursos [index];
        }
    }

    public class RegistroDictadoCursos 
    {
        public void AgregarDictadoCurso (DictadoCurso dictadoCurso) 
        {
            var db = GestorBD.ObtenerRegistros ();
            
            db.CursosDictados.Add (dictadoCurso);
            
            GestorBD.SobrescribirRegistros (db);
        }

        public void MostarCursosVigentes () 
        {
            var db = GestorBD.ObtenerRegistros ();
            
            List <DictadoCurso> cursosVigentes = db.CursosDictados.FindAll (x => x.Vigente == true);

            for (int i = 0; i < cursosVigentes.Count; i++) 
            {
                Console.Write ("\n" + (i + 1).ToString () + ". ");
            
                cursosVigentes [i].MostrarDictadoCurso ();
            }
        }

        public bool VerificarCursosVigentes () 
        {
            var db = GestorBD.ObtenerRegistros ();
            
            bool cursosVigentes = db.CursosDictados.Exists (x => x.Vigente == true);
            
            return cursosVigentes;
        }

        public DictadoCurso ObtenerCursoDictado (int index) 
        {
            var db = GestorBD.ObtenerRegistros ();
            
            return db.CursosDictados [index];
        }
        
        public void CancelarCurso (int index) 
        {
            var db = GestorBD.ObtenerRegistros ();
            
            db.CursosDictados [index].CancelarCurso();
            
            GestorBD.SobrescribirRegistros (db);
        }
    }

    public class RegistroInscripciones 
    {
        public void AgregarInscripcion (Inscripcion inscripcion) 
        {
            var db = GestorBD.ObtenerRegistros ();
            
            db.Inscripciones.Add (inscripcion);
            
            GestorBD.SobrescribirRegistros (db);
        }
    }

    public class RegistroProfesores 
    {
        public void AgregarProfesor (Profesor profesor) 
        {
            var db = GestorBD.ObtenerRegistros ();
            
            db.Profesores.Add (profesor);
            
            GestorBD.SobrescribirRegistros (db);
        }

        public void MostrarProfesores () 
        {
            var db = GestorBD.ObtenerRegistros ();

            for (int i = 0; i < db.Profesores.Count; i++) 
            {
                Console.Write ("\n" + (i + 1).ToString () + ". ");
                
                db.Profesores [i].MostarProfesor ();
            }
        }
        public Profesor ObtenerProfesor(int index ) 
        {
            var db = GestorBD.ObtenerRegistros ();
            
            return db.Profesores [index]; 
        }
    }

    public static class GestorBD 
    {
        public static BaseDatosModel ObtenerRegistros () 
        {
            string dbString = File.ReadAllText ("db.json");
            
            return JsonConvert.DeserializeObject <BaseDatosModel> (dbString);
        }

        public static void SobrescribirRegistros (BaseDatosModel db) 
        {
            string dbSerialized = JsonConvert.SerializeObject (db,Formatting.Indented );
            
            System.IO.File.WriteAllText ("db.json", dbSerialized);
        }
    }

    public  class BaseDatosModel 
    {
        public List <Alumno> Alumnos { get; set; }
        public List <Curso> Cursos { get; set; }
        public List <DictadoCurso> CursosDictados { get; set; }
        public List <Inscripcion> Inscripciones { get; set; }
        public List <Profesor> Profesores { get; set; }
    }
}
