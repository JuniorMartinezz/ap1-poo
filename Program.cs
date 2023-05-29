using ap1_poo.Data.Repositories;
using ap2_poo.Data.Repositories;
using ap2_poo.Domain;
using aula12_ef_test.Domain;
using poo_ap1;

class Program
{
    static void Main(string[] args)
    {
        string op;

        var db = new DataContext();
        SupplierRepository supplierRepository = new SupplierRepository(db);
        ProductRepository productRepository = new ProductRepository(db);
        CityRepository cityRepository = new CityRepository(db);
        BuyRepository buyRepository = new BuyRepository(db);

        System.Console.WriteLine("\nPrograma iniciado...");

        supplierRepository.GetAll();
        productRepository.GetAll();
        buyRepository.GetAll();
        cityRepository.GetAll();

        do
        {
            System.Console.WriteLine(
                "\nDigite o número do que deseja executar: \n\n1- Criar(Fornecedores e produtos) \n2- Editar (Fornecedores, produtos) \n3- Excluir (Fornecedores, produtos) \n4- Consultar(Fornecedores, produtos e compras) \n5- Efetuar compra \n0- Sair do programa\n"
            );
            op = Console.ReadLine();

            switch (op)
            {
                case "1": //Criar fornecedor ou produto
                    Create();

                    break;

                case "2": //Alterar fornecedor e produtos
                    Update();

                    break;

                case "3":
                    Delete();

                    break;

                case "4": //Consultar fornecedor, compras e produtos
                    Consult();

                    break;

                case "5": //Efetuar compra
                    if (productRepository.GetAll == null)
                    {
                        System.Console.WriteLine(
                            "\nNenhum produto cadastrado para efetuar compra!"
                        );
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

        void Create()
        {
            System.Console.WriteLine(
                "\nDigite o número correspondente ao processo que deseja realizar\n1- Fornecedor \n2- Produtos \n0- Sair\n"
            );

            string op = Console.ReadLine();

            if (op == "" || op == null)
            {
                System.Console.WriteLine("\nVocê precisa digitar um comando válido!");
                Environment.Exit(0);
            }

            switch (op)
            {
                case "1":
                    CreateSupplier();

                    break;

                case "2":
                    if (supplierRepository.GetAll().Count != 0)
                    {
                        CreateProduct();
                    }
                    else
                    {
                        System.Console.WriteLine(
                            "\nVocê precisa cadastrar um fornecedor primeiro!"
                        );
                    }

                    break;

                case "0":
                    break;

                default:
                    System.Console.WriteLine("\nDigite um código válido!");
                    break;
            }
        }
        void CreateSupplier() //Criador de fornecedor
        {
            //Secao id nome e cnpj

            System.Console.WriteLine("\nDigite o nome da empresa:");
            string inputName = Console.ReadLine()!;

            System.Console.WriteLine("\nDigite o cnpj da empresa:");
            long inputCnpj = Convert.ToInt64(Console.ReadLine());

            //Secao de telefone
            System.Console.WriteLine("\n| Telefone |");
            System.Console.WriteLine("\nDigite o número de telefone:");
            string inputPhoneNumber = Console.ReadLine();

            //Secao de cidade
            ListCities();
            /*             System.Console.WriteLine("\nDigite o id da cidade:");
                        int inputIdCity = Convert.ToInt32(Console.ReadLine()); */

            System.Console.WriteLine("\nDigite o nome da cidade:");
            string inputNameCity = Console.ReadLine();

            var cityFound = cityRepository.GetByName(inputNameCity);

            if (cityFound != null)
            {
                var supplier = new Supplier
                {
                    Name = inputName,
                    Phone = inputPhoneNumber,
                    Cnpj = inputCnpj,
                    City = cityFound
                };

                supplierRepository.Save(supplier);

                System.Console.WriteLine("\nFornecedor cadastrado!");
            }
            else
            {
                var newCity = new City { Name = inputNameCity };

                var supplier = new Supplier
                {
                    Name = inputName,
                    Phone = inputPhoneNumber,
                    Cnpj = inputCnpj,
                    City = newCity
                };

                supplierRepository.Save(supplier);

                System.Console.WriteLine("\nFornecedor cadastrado!");
            }
        }
        void CreateProduct() //Criador de produto
        {
            System.Console.WriteLine("\nDigite o código de barras:");
            string inputBarCode = Console.ReadLine();

            System.Console.WriteLine("\nDigite a descrição do produto:");
            string inputDescription = Console.ReadLine();

            System.Console.WriteLine("\nDigite o preço do produto:");
            double inputPrice = Convert.ToDouble(Console.ReadLine());

            ListSuppliers();
            System.Console.WriteLine("\nDigite o id do fornecedor:");
            int inputIdSupplier = Convert.ToInt32(Console.ReadLine());

            var newSupplier = new Supplier { Id = inputIdSupplier };

            var product = new Product()
            {
                Description = inputDescription,
                Price = inputPrice,
                BarCode = inputBarCode,
                Supplier = newSupplier
            };

            productRepository.Save(product);

            System.Console.WriteLine("\nProduto cadastrado!");
        }
        void Consult()
        {
            System.Console.WriteLine(
                "\nDigite o número correspondente ao tipo de consulta que deseja realizar\n1- Fornecedor \n2- Produtos \n3- Compras \n0- Sair\n"
            );

            string op = Console.ReadLine();

            switch (op)
            {
                case "1":
                    if (supplierRepository.GetAll().Count != 0)
                    {
                        ListSuppliers();
                    }
                    else
                    {
                        System.Console.WriteLine("\nNenhum fornecedor cadastrado!");
                    }

                    break;

                case "2":
                    if (productRepository.GetAll().Count != 0)
                    {
                        ListProducts();
                    }
                    else
                    {
                        System.Console.WriteLine("\nNenhum produto cadastrado!");
                    }

                    break;

                case "3":
                    if (buyRepository.GetAll().Count != 0)
                    {
                        ListBuys();
                    }
                    else
                    {
                        System.Console.WriteLine("\nNenhuma venda cadastrada!");
                    }

                    break;

                case "0":
                    break;

                default:
                    System.Console.WriteLine("\nDigite um código válido!");
                    break;
            }
        }
        void Update()
        {
            System.Console.WriteLine(
                "\nDigite o número correspondente ao tipo de edição que deseja realizar\n1- Fornecedor \n2- Produtos \n0- Sair\n"
            );

            string op = Console.ReadLine();

            switch (op)
            {
                case "1":
                    if (supplierRepository.GetAll().Count != 0)
                    {
                        UpdateSuppliers();
                    }
                    else
                    {
                        System.Console.WriteLine("\nNenhum fornecedor cadastrado para alterar!");
                    }

                    break;

                case "2":
                    if (productRepository.GetAll().Count != 0)
                    {
                        UpdateProducts();
                    }
                    else
                    {
                        System.Console.WriteLine("\nNenhum produto cadastrado para alterar!");
                    }

                    break;

                case "0":
                    break;

                default:
                    System.Console.WriteLine("\nDigite um código válido!");
                    break;
            }
        }
        void Delete()
        {
            System.Console.WriteLine(
                "\nDigite o número correspondente ao processo que deseja realizar\n1- Fornecedor \n2- Produtos \n0- Sair\n"
            );

            string op = Console.ReadLine();

            if (op == "" || op == null)
            {
                System.Console.WriteLine("\nVocê precisa digitar um comando válido!");
                Environment.Exit(0);
            }

            switch (op)
            {
                case "1":
                    if (supplierRepository.GetAll().Count != 0)
                    {
                        DeleteSupplier();
                    }
                    else
                    {
                        System.Console.WriteLine("\nNenhum fornecedor cadastrado!");
                    }

                    break;

                case "2":
                    if (productRepository.GetAll().Count != 0)
                    {
                        DeleteProduct();
                    }
                    else
                    {
                        System.Console.WriteLine("\nNenhum produto cadastrado!");
                    }

                    break;

                case "0":
                    break;

                default:
                    System.Console.WriteLine("\nDigite um código válido!");
                    break;
            }
        }
        void DeleteSupplier()
        {
            ListSuppliers();

            System.Console.WriteLine("\nDigite o id do fornecedor que deseja remover:");
            string idSupplier = Console.ReadLine();

            if (idSupplier != "")
            {
                var s = supplierRepository.GetById(Convert.ToInt32(idSupplier));

                if (s != null)
                {
                    supplierRepository.Delete(s.Id);

                    System.Console.WriteLine("\nFornecedor removido!");
                }
                else
                {
                    System.Console.WriteLine("\nO id digitado é inválido!");
                    return;
                }
            }
            else
            {
                System.Console.WriteLine("\nO id digitado é inválido!");
                return;
            }
        }
        void DeleteProduct()
        {
            ListProducts();

            System.Console.WriteLine("\nDigite o código de barras do produto que deseja remover:");
            string BarCodeProduct = Console.ReadLine();

            if (BarCodeProduct != "")
            {
                var p = productRepository.GetByBarCode(BarCodeProduct);

                if (p != null)
                {
                    productRepository.Delete(p.Id);

                    System.Console.WriteLine("\nProduto removido!");
                }
                else
                {
                    System.Console.WriteLine("\nCódigo de barras inválido!");
                }
            }
            else
            {
                System.Console.WriteLine("\nCódigo de barras inválido!");
            }
        }
        void UpdateSuppliers()
        {
            ListSuppliers();

            System.Console.WriteLine("\nDigite o id do fornecedor que deseja alterar:");
            string idSupplier = Console.ReadLine();

            if (idSupplier != "")
            {
                var s = supplierRepository.GetById(Convert.ToInt32(idSupplier));

                if (s != null)
                {
                    System.Console.WriteLine("\nDigite o nome da empresa:");
                    string inputName = Console.ReadLine();
                    s.Name = inputName == "" ? s.Name : inputName;

                    System.Console.WriteLine("\nDigite o cnpj da empresa:");
                    string inputCnpj = Console.ReadLine();
                    s.Cnpj = inputCnpj == "" ? s.Cnpj : Convert.ToInt64(inputCnpj);

                    //Secao de telefone
                    System.Console.WriteLine("\n| Telefone |");
                    System.Console.WriteLine("\nDigite o número de telefone:");
                    string inputPhone = Console.ReadLine();
                    s.Phone = inputPhone == "" ? s.Phone : inputPhone;

                    //Secao de cidade
                    ListCities();
                    System.Console.WriteLine("\nDigite o nome da cidade:");
                    string inputNameCity = Console.ReadLine();
                    string inputCity = inputNameCity == "" ? s.City.Name : inputNameCity;

                    var cityFound = cityRepository.GetByName(inputNameCity);

                    if (cityFound != null)
                    {
                        s.City = cityFound;

                        supplierRepository.Update(s);
                        System.Console.WriteLine("\nFornecedor alterado!");
                    }
                    else
                    {
                        var newCity = new City { Name = inputCity };

                        s.City = newCity;

                        supplierRepository.Update(s);

                        System.Console.WriteLine("\nFornecedor cadastrado!");
                    }
                }
                else
                {
                    System.Console.WriteLine("\nO id digitado é inválido!");
                    return;
                }
            }
            else
            {
                System.Console.WriteLine("\nO id digitado é inválido!");
                return;
            }
        }
        void UpdateProducts()
        {
            ListProducts();

            System.Console.WriteLine("\nDigite o codigo de barras do produto que deseja alterar:");
            string BarCodeProduct = Console.ReadLine();

            if (BarCodeProduct != "")
            {
                var p = productRepository.GetByBarCode(BarCodeProduct);

                if (p != null)
                {
                    System.Console.WriteLine("\nDigite o código de barras:");
                    string barCode = Console.ReadLine();
                    p.BarCode = barCode == "" ? p.BarCode : barCode;

                    System.Console.WriteLine("\nDigite a descrição do produto:");
                    string description = Console.ReadLine();
                    p.Description = description == "" ? p.Description : description;

                    System.Console.WriteLine("\nDigite o preço do produto:");
                    string price = Console.ReadLine();
                    p.Price = price == "" ? p.Price : Convert.ToDouble(price);

                    ListSuppliers();
                    System.Console.WriteLine("\nDigite o id do fornecedor:");
                    string inputIdSupplier = Console.ReadLine();

                    var newSupplier = new Supplier
                    {
                        Id =
                            inputIdSupplier == "" ? p.Supplier.Id : Convert.ToInt32(inputIdSupplier)
                    };

                    p.Supplier = newSupplier;

                    productRepository.Update(p);

                    System.Console.WriteLine("\nProduto alterado!");
                }
                else
                {
                    System.Console.WriteLine("\nCódigo de barras inválido!");
                }
            }
            else
            {
                System.Console.WriteLine("\nCódigo de barras inválido!");
            }
        }
        void ListSuppliers() //Listar Fornecedores
        {
            var suppliers = supplierRepository.GetAll();

            System.Console.WriteLine("\nLista de fornecedores\n");

            foreach (var item in suppliers)
            {
                var city = item.City == null ? "Sem Cidade" : item.City.Name;

                System.Console.WriteLine(
                    $"Id: {item.Id} | Nome: {item.Name} | Cnpj: {item.Cnpj} | Telefone: {item.Phone} | Cidade: {city}"
                );
            }
        }
        void Buy()
        {
            DateTime today = DateTime.Now;

            ListProducts();

            System.Console.WriteLine("\nDigite o código de barras do produto desejado:");
            string inputCodeBar = Console.ReadLine();

            System.Console.WriteLine("\nDigite a quantidade desejada:");
            int inputAmount = Convert.ToInt32(Console.ReadLine());

            double totalPrice;

            var productFound = productRepository.GetByBarCode(inputCodeBar);

            if (productFound != null)
            {
                Product selectedProduct = productRepository.GetByBarCode(inputCodeBar);

                totalPrice = (selectedProduct.Price * inputAmount);

                var buy = new Buy()
                {
                    Date = today,
                    Product = selectedProduct,
                    Amount = inputAmount,
                    TotalPrice = totalPrice
                };

                buyRepository.Save(buy);

                System.Console.WriteLine("\nCompra realizada!");
            }
            else
            {
                System.Console.WriteLine("\nCódigo de produto inválido!");
                return;
            }
        }
        void ListProducts()
        {
            var products = productRepository.GetAll();

            System.Console.WriteLine("\nLista de produtos\n");

            foreach (var item in products)
            {
                var supplier = item.Supplier == null ? "Sem Fornecedor" : item.Supplier.Name;

                System.Console.WriteLine(
                    $"Descrição: {item.Description} | Preço: {Product.CurrencyFormatter(item.Price)} | Código de barras: {item.BarCode} | Fornecedor: {supplier}"
                );
            }
        }
        void ListBuys()
        {
            var buys = buyRepository.GetAll();

            System.Console.WriteLine("Lista de Vendas\n");

            foreach (var item in buys)
            {
                var product = item.Product == null ? "Sem Produto" : item.Product.Description;

                var productPrice = item.Product == null ? 0 : item.Product.Price;

                System.Console.WriteLine(
                    $"Id da venda: {item.Id} | Data: {item.Date.ToString("dd/MM/yyyy hh:mm")} | Produto: {product} | Preço unitário: {Product.CurrencyFormatter(productPrice)} | Quantidade: {item.Amount} | Valor total: {Product.CurrencyFormatter(item.TotalPrice)}"
                );
            }
        }
        void ListCities()
        {
            var cities = cityRepository.GetAll();

            System.Console.WriteLine("\nLista de cidades\n");

            foreach (var item in cities)
            {
                System.Console.WriteLine($"Id: {item.Id} | Nome: {item.Name}");
            }
        }
    }
}
