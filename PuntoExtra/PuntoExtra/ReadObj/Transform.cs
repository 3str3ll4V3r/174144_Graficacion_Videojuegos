namespace ReadObj
{
    public class Transform
    {
        private readonly float _scale;
        private readonly Vertex _translation;
        public Matrix Rotation { get; set; }
        

        public Transform(float scale, Vertex translation,Matrix rotation=null)
        {
            this._scale = scale;
            this.Rotation = rotation ?? Matrix.Identity;
            this._translation = translation;
        }

        public Matrix transform()
        {
            Matrix m= Matrix.MakeTranslationMatrix(this._translation) * this.Rotation * Matrix.MakeScalingMatrix(this._scale);
            return m;
        }
    }
}
