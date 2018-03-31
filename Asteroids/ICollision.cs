using System.Drawing;

namespace Asteroids
{
    /// <summary>
    /// 
    /// </summary>
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}
