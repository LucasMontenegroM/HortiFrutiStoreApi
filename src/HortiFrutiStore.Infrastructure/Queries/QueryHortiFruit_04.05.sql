Create database HortiFrutiStore

create table Produtos (
	Id UniqueIdentifier not null primary key,
	Nome varchar(255) not null,
	ValorBase Decimal(18,2) not null,
	Desconto Decimal(18,2) null
)

	Insert into Produtos (Id, Nome, ValorBase)
	values (NEWID(), 'Banana', 15.00)

	select * from Produtos