using Assignments;
internal class Program {
    public static void assignmentsInterface(List<Assignment> pendingAssignments, List<Assignment> completedAssignments) {
        int validOption, validID;
        Console.WriteLine("----INTERFAZ----");
        Console.WriteLine("1-Mover tarea\n2-Buscar tarea");
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
            default:
                Console.WriteLine("\nOpcion no encontrada\n");
                break;
        }
    }

    public static void moveAssignment(List<Assignment> pendingAssignments, List<Assignment> completedAssignments, int id) {
        Assignment choseAssignment;
        foreach(Assignment assignment in pendingAssignments) {
            if(assignment.AssignmentID == id) {
                choseAssignment = assignment;
                choseAssignment.AssignmentCompleted = true;
                completedAssignments.Add(choseAssignment);
                pendingAssignments.Remove(assignment);
                return;
            }
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
        assignmentsInterface(pendingAssignments, completedAssignments);
    }

}