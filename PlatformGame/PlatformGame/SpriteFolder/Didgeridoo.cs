using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.GameFolder;

namespace PlatformGame.SpriteFolder
{
    class Didgeridoo : Sprite
    {
        public Vector2 position = new Vector2(1650, 0);
        public bool isVisible = true;
        private Texture2D texture;
        private int velocity;
        private float angle;
        private float rotation = .1f;

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)position.X - (int)Origin.X, (int)position.Y - (int)Origin.Y, texture.Width, texture.Height); }
        }

        public Vector2 Origin;

        public readonly Color[] TextureData;

        public Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(-Origin, 0)) *
                    Matrix.CreateRotationZ(rotation) *
                    Matrix.CreateTranslation(new Vector3(position, 0));
            }
        }

        public Didgeridoo(int _positionY, int _velocity)
        {
            Load();

            position.Y = _positionY;

            velocity = _velocity;

            Origin = new Vector2(texture.Width / 2, texture.Height / 2);

            TextureData = new Color[texture.Width * texture.Height];
            texture.GetData(TextureData);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, angle, Origin, .2f, SpriteEffects.None, 0);
        }

        public override void Load()
        {
            texture = Resources.LoadFile["didgeridoo"];
            //Rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, texture.Width, texture.Height);
        }

        public override void Update(GameTime gameTime)
        {
            //Rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, texture.Width, texture.Height);
            //movement + turning
            angle += rotation;
            position.X -= velocity;

            if (this.position.X < 0)
                this.isVisible = false;
        }

        //ONLY TRYING per pixel collisiondetection (Thanks @Oyyou)

        public bool Intersects(Didgeridoo sprite)
        {
            // Calculate a matrix which transforms from A's local space into
            // world space and then into B's local space
            var transformAToB = this.Transform * Matrix.Invert(sprite.Transform);

            // When a point moves in A's local space, it moves in B's local space with a
            // fixed direction and distance proportional to the movement in A.
            // This algorithm steps through A one pixel at a time along A's X and Y axes
            // Calculate the analogous steps in B:
            var stepX = Vector2.TransformNormal(Vector2.UnitX, transformAToB);
            var stepY = Vector2.TransformNormal(Vector2.UnitY, transformAToB);

            // Calculate the top left corner of A in B's local space
            // This variable will be reused to keep track of the start of each row
            var yPosInB = Vector2.Transform(Vector2.Zero, transformAToB);

            for (int yA = 0; yA < this.Rectangle.Height; yA++)
            {
                // Start at the beginning of the row
                var posInB = yPosInB;

                for (int xA = 0; xA < this.Rectangle.Width; xA++)
                {
                    // Round to the nearest pixel
                    var xB = (int)Math.Round(posInB.X);
                    var yB = (int)Math.Round(posInB.Y);

                    if (0 <= xB && xB < sprite.Rectangle.Width &&
                        0 <= yB && yB < sprite.Rectangle.Height)
                    {
                        // Get the colors of the overlapping pixels
                        var colourA = this.TextureData[xA + yA * this.Rectangle.Width];
                        var colourB = sprite.TextureData[xB + yB * sprite.Rectangle.Width];

                        // If both pixel are not completely transparent
                        if (colourA.A != 0 && colourB.A != 0)
                        {
                            return true;
                        }
                    }

                    // Move to the next pixel in the row
                    posInB += stepX;
                }

                // Move to the next row
                yPosInB += stepY;
            }

            // No intersection found
            return false;
        }

        public bool OnCollide(Sprite sprite)
        {
            if (sprite == this)
                return false;

            if (sprite is Didgeridoo)
                return false;

            return true;
        }
    }
}
