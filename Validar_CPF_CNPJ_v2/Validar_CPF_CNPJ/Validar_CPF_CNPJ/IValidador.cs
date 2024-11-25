using OutSystems.ExternalLibraries.SDK;

namespace Validar_CPF_CNPJ; 
[OSInterface
(
    Description = "Validador de CPF e CNPJ.",
    IconResourceName = "Validar_CPF_CNPJ.resources.validador.png",
    Name = "Validar_CPF_CNPJ"
)
]
public interface IValidador {
    [OSAction(
        Description = "Ação para validar CPF.",
        ReturnDescription = "Retorna true se CPF informado for válido.",
        ReturnName = "IsCPFValido",
        ReturnType = OSDataType.Boolean
    )]
    public bool ValidarCPF([OSParameter(DataType = OSDataType.Text, Description = "CPF a ser validado.")] string cpf);

    [OSAction(
        Description = "Ação para validar CNPJ.",
        ReturnDescription = "Retorna true se CNPJ informado for válido.",
        ReturnName = "IsCNPJValido",
        ReturnType = OSDataType.Boolean
    )]
    public bool ValidarCNPJ([OSParameter(DataType = OSDataType.Text, Description = "CNPJ a ser validado.")] string cnpj);
}

