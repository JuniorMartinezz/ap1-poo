using System.Text.RegularExpressions;
using poo_ap1;
class Program
{
    static void Main(string[] args)
    {
        string op;

        System.Console.WriteLine("\nPrograma iniciado...");

        do
        {
            System.Console.WriteLine
            (
                "\nDigite o número do que deseja executar: \n\n1- Criar(Fornecedores, produtos e compras) \n2- Consultar(Fornecedores, produtos e compras) \n3- Efetuar compra \n0- Sair do programa\n"
            );
            op = Console.ReadLine();

            switch (op)
            {
                case "1": //Criar fornecedor ou produto
                    Create();

                    break;

                case "2": //Consultar fornecedor, compras e produtos
                    Consult();

                    break;

                case "3": //Efetuar compra
                    if (CooktopRepository.CooktopsList.Count == 0 || FridgeRepository.FridgesList.Count == 0)
                    {
                        System.Console.WriteLine("\nNenhum produto cadastrado para efetuar compra!");
                    }
                    else
                    {
                        Buy();
                    }

                    break;

                default:
                    System.Console.WriteLine("\nDigite um código válido!");
                    break;
            }
        } while (op != "0");
        System.Console.WriteLine("\nSistema Encerrado!");
    }

    static void CreateProduct() //Criador de produto
    {
        string nameOfProduct;

        System.Console.WriteLine("\nDigite o número correspondente ao tipo de produto que deseja cadastrar\n1- Geladeira \n2- Cooktop \n0- Sair\n");

        string op = Console.ReadLine();

        if (op == "" || op == null)
        {
            System.Console.WriteLine("Você precisa digitar um comando válido!");
            Environment.Exit(0);
        }

        switch (op)
        {
            case "1":
                nameOfProduct = "Geladeira";
                CreateFridge(nameOfProduct);
                break;

            case "2":
                nameOfProduct = "Cooktop";
                CreateCooktop(nameOfProduct);
                break;

            case "0":
                break;

            default:
                System.Console.WriteLine("\nDigite um código válido!");
                break;
        }
    }
    static void CreateFridge(string nameOfProduct) //Criador de geladeira
    {
        string inputName = nameOfProduct;

        System.Console.WriteLine("\nDigite seu código de barras:");
        long inputBarCode = Convert.ToInt64(Console.ReadLine());

        //Secao modelo, cor, tipo
        System.Console.WriteLine("\nDigite a marca do produto:");
        string inputBrand = Console.ReadLine();

        System.Console.WriteLine("\nDigite a capacidade produto: (Em litros)");
        int inputCapacity = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine("\nDigite a cor do produto:");
        string inputColor = Console.ReadLine();

        System.Console.WriteLine("\nDigite o preço do produto:");
        double inputPrice = Convert.ToDouble(Console.ReadLine());

        //Definindo fornecedor do produto
        System.Console.WriteLine("| Lista de fornecedores |");
        ListSuppliers();
        System.Console.WriteLine("\nDigite o id correspondente ao fornecedor do produto:");
        int inputId = Convert.ToInt32(Console.ReadLine());

        //Montagem do objeto produto
        Fridge fridge = new Fridge(inputBarCode, inputName, inputBrand, inputPrice, SupplierRepository.get(inputId), inputCapacity, inputColor);

        FridgeRepository.Add(fridge);

        System.Console.WriteLine("\nGeladeira cadastrada!");
    }
    static void CreateCooktop(string nameOfProduct) //Criador de cooktop
    {
        string inputName = nameOfProduct;

        //Secao codigo de barras e categoria
        System.Console.WriteLine("\nDigite seu código de barras:");
        long inputBarCode = Convert.ToInt64(Console.ReadLine());

        //Secao modelo, bocas, tipo, material
        System.Console.WriteLine("\nDigite a marca do produto:");
        string inputBrand = Console.ReadLine();

        System.Console.WriteLine("\nDigite a quantidade de bocas que o cooktop possui:");
        int inputBurners = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine("\nDigite o material do produto:");
        string inputMaterial = Console.ReadLine();

        System.Console.WriteLine("\nDigite o preço do produto:");
        double inputPrice = Convert.ToDouble(Console.ReadLine());

        //Definindo fornecedor do produto
        System.Console.WriteLine("| Lista de fornecedores |");
        ListSuppliers();
        System.Console.WriteLine("\nDigite o id correspondente ao fornecedor do produto:");
        int inputId = Convert.ToInt32(Console.ReadLine());

        //Montagem do objeto produto
        Cooktop cooktop = new Cooktop(inputBarCode, inputName, inputBrand, inputPrice, SupplierRepository.get(inputId), inputBurners, inputMaterial);

        CooktopRepository.Add(cooktop);

        System.Console.WriteLine("\nCooktop cadastrado!");
    }
    static void CreateSupplier() //Criador de fornecedor
    {
        //Secao id nome e cnpj
        System.Console.WriteLine("\nDigite o id:");
        int idSupplier = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine("\nDigite o nome da empresa:");
        string inputName = Console.ReadLine()!;

        System.Console.WriteLine("\nDigite o cnpj da empresa:");
        long inputCnpj = Convert.ToInt64(Console.ReadLine());

        //Secao de telefone
        System.Console.WriteLine("\n| Telefone |");
        System.Console.WriteLine("\nDigite o código de país: (Ex: 55)");
        int inputCountryCode = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine("\nDigite o código de região: (Ex: 51)");
        int inputAreaCode = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine("\nDigite o número de telefone:");
        long inputPhoneNumber = Convert.ToInt64(Console.ReadLine());

        //Montagem do objeto telefone
        Phone phone = new Phone(inputCountryCode, inputAreaCode, inputPhoneNumber);

        //Secao de endereco
        System.Console.WriteLine("\n| Endereço |:");
        System.Console.WriteLine("\nDigite a rua/avenida:");
        string inputStreet = Console.ReadLine();

        System.Console.WriteLine("\nDigite o número:");
        int inputAddressNumber = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine("\nDigite a cidade:");
        string inputCity = Console.ReadLine();

        System.Console.WriteLine("\nDigite o estado:");
        string inputState = Console.ReadLine();

        //Montagem do objeto endereco
        Address address = new Address(inputStreet, inputAddressNumber, inputCity, inputState);

        //Montagem do objeto fornecedor
        Supplier supplier = new Supplier(idSupplier, inputName, phone, address, inputCnpj);

        SupplierRepository.Add(supplier);

        System.Console.WriteLine("\nFornecedor cadastrado!");
    }
    static void ListCooktops() //Listar Cooktops
    {
        CooktopRepository.get();
    }
    static void ListCooktops(int codeBar) //Listar Cooktops
    {
        CooktopRepository.get(codeBar);
    }
    static void ListFridges() //Listar Geladeiras
    {
        FridgeRepository.get();
    }
    static void ListProducts()
    {
        System.Console.WriteLine("\nDigite o código de barras do produto que deseja consultar:");
        long inputCodeBar = Convert.ToInt64(Console.ReadLine());

        if (CooktopRepository.CooktopsList.Count == 0 || FridgeRepository.FridgesList.Count == 0)
        {
            System.Console.WriteLine("\nLista de produtos vazia!");
        }
        else
        {
            if (CooktopRepository.getOne(inputCodeBar) != null)
            {
                CooktopRepository.get(inputCodeBar);
            }
            else if (FridgeRepository.getOne(inputCodeBar) != null)
            {
                FridgeRepository.get(inputCodeBar);
            }
            else
            {
                System.Console.WriteLine("\nCódigo de barras inválido!");
                Environment.Exit(0);
            }
        }
    }
    static void ListSuppliers() //Listar Fornecedores
    {
        SupplierRepository.getAll();
    }
    static void Buy()
    {
        DateTime today = DateTime.Now;

        ListProducts();

        System.Console.WriteLine("\nDigite o id da compra:");
        int idBuy = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine("\nDigite o código de barras do produto desejado:");
        long inputCodeBar = Convert.ToInt64(Console.ReadLine());

        System.Console.WriteLine("\nDigite a quantidade desejada:");
        int inputAmount = Convert.ToInt32(Console.ReadLine());

        double totalPrice;

        if (CooktopRepository.getOne(inputCodeBar) != null)
        {
            Cooktop selectedCooktop = CooktopRepository.getOne(inputCodeBar);

            totalPrice = (selectedCooktop.Price * inputAmount);

            Buy buy = new Buy(idBuy, today, selectedCooktop, inputAmount, totalPrice);

            BuyRepository.Add(buy);

            System.Console.WriteLine("\nCompra realizada!");
        }
        else if (FridgeRepository.getOne(inputCodeBar) != null)
        {
            Fridge selectedFridge = FridgeRepository.getOne(inputCodeBar);

            totalPrice = (selectedFridge.Price * inputAmount);

            Buy buy = new Buy(idBuy, today, selectedFridge, inputAmount, totalPrice);

            BuyRepository.Add(buy);

            System.Console.WriteLine("\nCompra realizada!");
        }
        else
        {
            System.Console.WriteLine("Código de produto inválido!");
            Environment.Exit(0);
        }
    }
    static void ListBuys()
    {
        BuyRepository.get();
    }
    static void Consult()
    {
        System.Console.WriteLine("\nDigite o número correspondente ao tipo de consulta que deseja realizar\n1- Fornecedor \n2- Produtos \n3- Compras \n0- Sair\n");

        string op = Console.ReadLine();

        if (op == "" || op == null)
        {
            System.Console.WriteLine("Você precisa digitar um comando válido!");
            Environment.Exit(0);
        }

        switch (op)
        {
            case "1":
                ListSuppliers();

                break;

            case "2":
                ListProducts();

                break;

            case "3":
                ListBuys();

                break;

            case "0":
                break;

            default:
                System.Console.WriteLine("\nDigite um código válido!");
                break;
        }
    }
    static void Create()
    {
        System.Console.WriteLine("\nDigite o número correspondente ao processo que deseja realizar\n1- Fornecedor \n2- Produtos \n0- Sair\n");

        string op = Console.ReadLine();

        if (op == "" || op == null)
        {
            System.Console.WriteLine("Você precisa digitar um comando válido!");
            Environment.Exit(0);
        }

        switch (op)
        {
            case "1":
                CreateSupplier();

                break;

            case "2":
                if (SupplierRepository.SuppliersList.Count == 0)
                {
                    System.Console.WriteLine("\nVocê precisa adicionar fornecedores primeiro!");
                }
                else
                {
                    CreateProduct();
                }

                break;

            case "0":
                break;

            default:
                System.Console.WriteLine("\nDigite um código válido!");
                break;
        }
    }
}

