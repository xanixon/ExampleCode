public struct BoatFitterConfig
{
    public BoatMotorConfig Motor;
    public OarConfig Oar;
    public BoatFitterConfig(BoatMotorConfig motor, OarConfig oar)
    {
        Motor = motor;
        Oar = oar;
    }
}