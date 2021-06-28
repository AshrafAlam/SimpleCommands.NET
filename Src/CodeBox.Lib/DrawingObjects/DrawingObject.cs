namespace ShapeCreator.Core.DrawingObjects
{
    public abstract class DrawingObject
    {
        private PixelChar _pixelChar;
        protected PixelChar PixelChar => _pixelChar ?? (_pixelChar = new PixelChar());
        protected readonly Canvas Canvas;

        protected DrawingObject(Canvas canvas, PixelChar pixelChar = null)
        {
            Canvas = canvas;
            _pixelChar = pixelChar;
        }

        public abstract void Draw();
    }
}