
using Academia;

// tabla estudiantes___________________________________________________________
estudiante miEstudiante1 = new estudiante("pepe", "perez", "123456789A");
// tabla asignaturas___________________________________________________________
asignatura mates = new asignatura("MATE1", "Matematicas");
// tabla matriculas____________________________________________________________
Dictionary<string, matricular> listaCursos = new Dictionary<string, matricular>();
matricular m = new matricular(miEstudiante1, mates);
listaCursos.Add("2025", m);

 