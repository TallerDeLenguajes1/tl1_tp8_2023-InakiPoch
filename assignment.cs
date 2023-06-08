namespace Assignments {
    public class Assignment {
        private int assignmentID;
        private string assignmentDescription;
        private int assignmentDuration;

        public Assignment(int id, string description, int duration) {
            this.assignmentID = id;
            this.assignmentDescription = description;
            this.assignmentDuration = duration;
        }
    }
}