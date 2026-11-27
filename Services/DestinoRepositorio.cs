using AuroraTravelAgency.Models;

namespace AuroraTravelAgency.Services;

public interface IDestinoRepositorio
{
    IReadOnlyList<Destino> ObtenerTodos();
    Destino? ObtenerPorId(int id);
}

/// <summary>
/// Repositorio en memoria con los destinos de la agencia.
/// (Los precios son ilustrativos para este proyecto académico.)
/// </summary>
public class DestinoRepositorio : IDestinoRepositorio
{
    private readonly List<Destino> _destinos = new()
    {
        new Destino
        {
            Id = 1,
            Nombre = "Islandia",
            CiudadBase = "Reikiavik",
            Emoji = "🌋",
            ImagenUrl = "/images/destinos/islandia.jpg",
            ImagenAlt = "Aurora boreal sobre montañas nevadas en el sur de Islandia.",
            ImagenAutor = "Tetiana Stepanets",
            ImagenLicencia = "CC BY-SA 4.0",
            ImagenFuenteUrl = "https://commons.wikimedia.org/wiki/File:Aurora_borealis_over_snowy_mountains,_South_Iceland_(DSC01438).jpg",
            ClaseTema = "tema-islandia",
            Resumen = "Auroras sobre glaciares, cascadas y campos de lava.",
            Descripcion = "Islandia combina cielos oscuros, paisajes volcánicos y aguas geotermales. " +
                          "Es un destino ideal para quienes quieren alternar la caza de auroras con rutas " +
                          "de día por cascadas, playas de arena negra y glaciares.",
            MejorEpoca = "Septiembre a marzo",
            PrecioPorPersonaPorNoche = 150m,
            PrecioTourAuroras = 95m,
            LugaresAuroras = new List<string>
            {
                "Parque Nacional Þingvellir",
                "Península de Snæfellsnes",
                "Laguna glaciar Jökulsárlón",
                "Costa sur: Vík y Reynisfjara"
            },
            Actividades = new List<string>
            {
                "Tour nocturno de auroras en autobús o 4x4",
                "Baño en aguas geotermales",
                "Ruta del Círculo Dorado",
                "Cuevas de hielo (temporada de invierno)"
            }
        },
        new Destino
        {
            Id = 2,
            Nombre = "Noruega",
            CiudadBase = "Tromsø",
            Emoji = "🏔️",
            ImagenUrl = "/images/destinos/noruega.jpg",
            ImagenAlt = "Aurora boreal sobre Noruega.",
            ImagenAutor = "Rafal Konieczny",
            ImagenLicencia = "CC BY 2.5",
            ImagenFuenteUrl = "https://commons.wikimedia.org/wiki/File:Aurora_Borealis_NO.JPG",
            ClaseTema = "tema-noruega",
            Resumen = "Fiordos, islas y la \"capital de las auroras\" en el Ártico.",
            Descripcion = "Desde Tromsø, en el norte del país, es posible salir cada noche en busca de " +
                          "auroras y combinarlo con cruceros por fiordos, trineos de perros y las " +
                          "montañas de las islas Lofoten.",
            MejorEpoca = "Septiembre a marzo",
            PrecioPorPersonaPorNoche = 185m,
            PrecioTourAuroras = 110m,
            LugaresAuroras = new List<string>
            {
                "Tromsø y alrededores",
                "Islas Lofoten",
                "Alta",
                "Isla de Senja"
            },
            Actividades = new List<string>
            {
                "Crucero por fiordos con búsqueda de auroras",
                "Paseo en trineo de perros husky",
                "Teleférico Fjellheisen sobre Tromsø",
                "Observación de ballenas (invierno)"
            }
        },
        new Destino
        {
            Id = 3,
            Nombre = "Finlandia",
            CiudadBase = "Rovaniemi",
            Emoji = "🦌",
            ImagenUrl = "/images/destinos/finlandia.jpg",
            ImagenAlt = "Aurora boreal reflejada en el lago Inari, Finlandia.",
            ImagenAutor = "Ababamov",
            ImagenLicencia = "CC BY-SA 4.0",
            ImagenFuenteUrl = "https://commons.wikimedia.org/wiki/File:Aurora_Borealis_and_the_stars.jpg",
            ClaseTema = "tema-finlandia",
            Resumen = "Laponia, iglús de cristal y noches bajo el cielo verde.",
            Descripcion = "La Laponia finlandesa ofrece bosques nevados, saunas tradicionales y alojamientos " +
                          "con techo de cristal para ver las auroras desde la cama. Es el destino más " +
                          "acogedor para viajar en familia.",
            MejorEpoca = "Finales de agosto a abril",
            PrecioPorPersonaPorNoche = 140m,
            PrecioTourAuroras = 90m,
            LugaresAuroras = new List<string>
            {
                "Rovaniemi y el Círculo Polar Ártico",
                "Saariselkä",
                "Lago Inari",
                "Iglús de cristal en Laponia"
            },
            Actividades = new List<string>
            {
                "Safari en moto de nieve",
                "Paseo en trineo de renos y huskies",
                "Sauna finlandesa tradicional",
                "Visita al Pueblo de Santa Claus"
            }
        }
    };

    public IReadOnlyList<Destino> ObtenerTodos() => _destinos;

    public Destino? ObtenerPorId(int id) => _destinos.FirstOrDefault(d => d.Id == id);
}
