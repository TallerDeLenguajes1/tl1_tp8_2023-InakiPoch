using Assignments;
internal class Program {
    public static void assignmentsInterface(List<Assignment> pendingAssignments, List<Assignment> completedAssignments) {
        int validOption, validID, validShowOption;
        Console.WriteLine("----INTERFAZ----");
        Console.WriteLine("1-Mover tarea\n2-Buscar tarea\n3-Actualizar sumario\n4-Mostrar lista");
        string? option = Console.ReadLine();
        while(!int.TryParse(option, out validOption)) {
            Console.WriteLine("\nIngresar una opcion valida");
            option = Console.ReadLine();
        }
        switch(validOption) {
            case 1:
                Console.WriteLine("\nIngresar el ID de la tarea a marcar como completada");
                string? id = Console.ReadLine();
                while(!int.TryParse(id, out validID)) {
                    Console.WriteLine("\nIngresar una ID valida");
                    id = Console.ReadLine();
                }
                moveAssignment(pendingAssignments, completedAssignments, validID);
                break;
            case 2:
                Console.WriteLine("\nIngresar la descripcion de la tarea a buscar");
                string? description = Console.ReadLine();
                while(description == null) {
                    Console.WriteLine("\nIngresar una descripcion valida");
                    description = Console.ReadLine();
                }
                SearchAssignment(pendingAssignments, description);
                break;
            case 3:
                int pendingDuration = 0, completedDuration = 0;
                foreach(Assignment assignment in pendingAssignments) { pendingDuration += assignment.AssignmentDuration; }
                foreach(Assignment assignment in completedAssignments) { completedDuration += assignment.AssignmentDuration; }
                using (StreamWriter summary = new StreamWriter("Summary.txt")) {
                    summary.WriteLine(completedDuration + pendingDuration);
                }
                break;
            case 4:
                Console.WriteLine("\nElegir lista a mostrar\n1-Pendientes\n2-Completas");
                string? showOption = Console.ReadLine();
                 while(!int.TryParse(showOption, out validShowOption)) {
                    Console.WriteLine("\nIngresar una opcion valida");
                    showOption = Console.ReadLine();
                }
                switch(validShowOption) {
                    case 1:
                        Console.WriteLine("\n---TAREAS PENDIENTES---\n");
                        foreach(Assignment assignment in pendingAssignments) {
                            assignment.DisplayData();
                        }
                        break;
                    case 2:
                        Console.WriteLine("\n---TAREAS COMPLETADAS---\n");
                        foreach(Assignment assignment in completedAssignments) {
                            assignment.DisplayData();
                        }
                        break;
                    default:
                        Console.WriteLine("\nNo se encontro la lista\n");
                        break;
                }
                break; 
            default:
                Console.WriteLine("\nOpcion no encontrada\n");
                break;
        }
    }

    public static void moveAssignment(List<Assignment> pendingAssignments, List<Assignment> completedAssignments, int id) {
        Assignment? choseAssignment = pendingAssignments.Find(assignment => assignment.AssignmentID == id);
        if(!(choseAssignment == null) && pendingAssignments.Remove(choseAssignment)) {
            choseAssignment.AssignmentCompleted = true;
            completedAssignments.Add(choseAssignment);
            return;
        }
        Console.WriteLine("\nNo se encontro la tarea especificada\n");
    }

    public static void SearchAssignment(List<Assignment> pendingAssignments, string description) {
        foreach(Assignment assignment in pendingAssignments) {
            if(assignment.AssignmentDescription == description) {
                Console.WriteLine("\n---INFORMACION DE LA TAREA---");
                assignment.DisplayData();
                return;
            }
        }
        Console.WriteLine("\nNo se encontro la tarea especificada\n");
    }

    private static void Main(string[] args) {
        const int maxAssignments = 10;
        string[] descriptions = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};
        var pendingAssignments = new List<Assignment>();
        var completedAssignments = new List<Assignment>();
        for(int i = 0; i < maxAssignments; i++) {
            pendingAssignments.Add(new Assignment(i + 1, descriptions[i], (new Random()).Next(10, 101), false));
        }
        do {
            assignmentsInterface(pendingAssignments, completedAssignments);
        } while(Console.ReadKey().Key != ConsoleKey.Escape);
    }
}