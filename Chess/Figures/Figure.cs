namespace Chess
{
    abstract class Figure
    {
        public char name { get; private set; }
        public Colour colour { get; private set; }
        public Square square { get; internal set; }
        public Figure(char name, Colour colour, Square square)
        {
            this.name = name;
            this.colour = colour;
            this.square = square;
        }
        public abstract bool CanFigureMove();
    }
}