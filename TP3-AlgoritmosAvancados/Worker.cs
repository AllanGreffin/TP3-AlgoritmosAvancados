namespace TP3_AlgoritmosAvancados
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //    await Task.Delay(1000, stoppingToken);
            //}
            
        }

        public void SolucaoA()
        {
            List<Item> listaDeItens = new List<Item>();
            int PesoSuportadoPelaMochila = 100;
            decimal pesoAtualNaMochila = 0;

            //Inserir os itens que desejar na lista

            listaDeItens = listaDeItens.OrderByDescending(x => x.ValorPorPeso).ToList();

            List<Item> itensASeremInseridos = new();

            while (pesoAtualNaMochila < PesoSuportadoPelaMochila && listaDeItens.Count > 0)
            {
                Item item = listaDeItens.First();
                listaDeItens.Remove(item);

                if (pesoAtualNaMochila + item.Peso <= PesoSuportadoPelaMochila)
                {
                    itensASeremInseridos.Add(item);
                    pesoAtualNaMochila += item.Peso;
                }
            }
        }

        public void SolucaoB()
        {
            List<Item> listaDeItens = new List<Item>();
            int PesoSuportadoPelaMochila = 100;
            decimal pesoAtualNaMochila = 0;

            //Inserir os itens que desejar na lista

            listaDeItens = listaDeItens.OrderByDescending(x => x.ValorPorPeso).ToList();

            List<Item> itensASeremInseridos = new();

            while (pesoAtualNaMochila < PesoSuportadoPelaMochila && listaDeItens.Count > 0)
            {
                Item item = listaDeItens.First();
                listaDeItens.Remove(item);

                if (pesoAtualNaMochila + item.Peso <= PesoSuportadoPelaMochila)
                {
                    itensASeremInseridos.Add(item);
                    pesoAtualNaMochila += item.Peso;
                }
                else
                {
                    decimal pesoRestante = PesoSuportadoPelaMochila - pesoAtualNaMochila;
                    Item itemFracionado = new Item();
                    itemFracionado.Peso = pesoRestante;
                    itemFracionado.Valor = itemFracionado.Peso * item.ValorPorPeso;
                    itensASeremInseridos.Add(itemFracionado);
                }
            }
        }
    }

    public class Item
    {
        public decimal Peso { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorPorPeso { get { return Valor / Peso; } }
    }
}