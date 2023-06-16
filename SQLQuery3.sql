use Negocios2022
go
Create or alter proc usp_clientes
AS
Select id, nombre, direccion, idpais, fono
from tb_clientes
go
