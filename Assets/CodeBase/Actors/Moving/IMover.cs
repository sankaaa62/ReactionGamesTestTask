namespace CodeBase.Actors.Moving
{
    public interface IMover
    {
        public float Speed { get; set; }
        public float AngularSpeed { get; set; }
    }
}