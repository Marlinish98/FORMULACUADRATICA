public partial class formulaCuadraticaViewModel : ObservableObject // sirve partial para particionar las clases entre si 
{
    [ObservableProperty]

    private double a; // se debe usar primero minuscula

    [ObservableProperty]
    private double b;

    [ObservableProperty]
    private double c;

    [ObservableProperty]
    private double x1;

    [ObservableProperty]
    private double x2;

    [RelayCommand]
    private async async Calcular()// hace varias tareas a la vez para sincronizar
    {
        FormulaCuadratica formulaCuadratica = new FormulaCuadratica(A,B,C);// al usar la primera letra debe de ser mayuscula
        if(FormulaCuadratica.A == 0)
        {
            await Application.Current!.MainPage.DisplayAlert("Advertencia","EL coefiente 'a' no puede ser cero","Aceptar");
        }
        else
        {
            double discriminante = Math.Pow(formulaCuadratica.B,2)-4 * formulaCuadratica.C;
            if(discriminante >= 0)
            {
                x1 = (-formulaCuadratica.B + Math.Sqrt(discriminante)) /( 2 * formulaCuadratica.C);
                x2 = (-formulaCuadratica.B - Math.Sqrt(discriminante)) /( 2 * formulaCuadratica.C);
            }
            else
            {
              await Application.Current!.MainPage.DisplayAlert("ADVERTENCIA","No se puede calcular Raiz con numero Negativos",""); 
            }
        }
        [RelayCommand]
        {
            A = 0;
            B = 0;
            C = 0;
            x1 =0;
            x2 =0;
        }
    }

}