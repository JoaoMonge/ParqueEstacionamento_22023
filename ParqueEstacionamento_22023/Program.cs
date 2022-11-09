var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

ParqueEstacionamento parque = new ParqueEstacionamento(3);

app.MapGet("/", () => parque.listar());
app.MapGet("/entrar/{matricula}", (string matricula) => parque.entrar(new Carro(matricula)));
app.MapGet("/sair/{matricula}", (string matricula) => parque.sair(matricula));
app.Run();


/*

Criar um sistema de um
parque de estacionamento
que permita os carros entrarem e sairem.
 
*/
class Carro {
    //Variáveis da classe
    public String matricula;

    //Constructor
    public Carro(String matricula)
    {
        this.matricula = matricula;
    }
}

class ParqueEstacionamento
{
    //Lista dinâmica (Não precisa de tamanho)
    List<Carro> estacionados = new List<Carro>();
    int capacidade;

    //Constructor
    public ParqueEstacionamento(int capacidade){
        this.capacidade = capacidade;
    }

    //Lista todos os carros que se encontram no parque
    public String listar()
    {
        String carros = "Estacionados:\n";

        foreach(Carro car in estacionados)
        {
            carros += car.matricula + "\n";
        }

        return carros;

    }

    //Entrar um carro no parque
    public String entrar(Carro c)
    {
        //Ver se existe lugar
        if( estacionados.Count < capacidade)
        {
            estacionados.Add(c);
            return $"O carro com matricula {c.matricula} entrou no parque.";
        }
        else
        {
            return "Parque completo";
        }
    }

    //Sair um carro no parque
    public String sair(String matricula)
    {
        Carro toRemove = null;

        foreach(Carro car in estacionados)
        {
            if(car.matricula.Equals(matricula))
            {
                toRemove = car;
                break;
            }
        }

        if( toRemove != null)
        {
            estacionados.Remove(toRemove);
            return $"O carro {toRemove.matricula} saiu do parque.";
        }
        else
        {
            return "O carro não se encontra no parque.";
        }
    }


}