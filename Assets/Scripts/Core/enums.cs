namespace Core
{
    public enum AsteroidSize
    {
        Big,
        Medium,
        Small
    }
    
    public enum bulletType
    {
        Laser
    }

    public enum PoolTypes
    {
        Asteroids,
        PlayerProjectile
    }
    
    public enum SFXType
    {
        Explosion = 0,
        Bullet = 1,
        ButtonsHover = 2,
        ButtonsClick = 3,
        GameMusic = 4,
    }

    public enum GameState
    {
        None = 0,
        Easy = 1,
        Medium = 2,
        Hard = 3,
        GameOver = 4
    }
}