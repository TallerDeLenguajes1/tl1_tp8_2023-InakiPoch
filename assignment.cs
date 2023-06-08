namespace Assignments {
    public class Assignment {
        private int assignmentID;
        private string assignmentDescription;
        private int assignmentDuration;
        private bool assignmentCompleted;

        public string AssignmentDescription { get => assignmentDescription; }
        public int AssignmentID { get => assignmentID; }
        public bool AssignmentCompleted { get => assignmentCompleted; set => assignmentCompleted = value; }
        public Assignment(int id, string description, int duration, bool state) {
            this.assignmentID = id;
            this.assignmentDescription = description;
            this.assignmentDuration = duration;
            this.assignmentCompleted = state;
        }
        public void DisplayData() {
            Console.WriteLine("ID: " + this.assignmentID);
            Console.WriteLine("Descripcion: " + this.assignmentDescription);
            Console.WriteLine("Duracion: " + this.assignmentDuration + "\n");
        }
    }
}