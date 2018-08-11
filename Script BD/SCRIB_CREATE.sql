CREATE TABLE departamento(
	direccion varchar(256) UNIQUE NOT NULL,
	codigo_postal integer NOT NULL,
	primary key (direccion)
);

CREATE TABLE cliente(
	rut varchar(256) UNIQUE NOT NULL,
	nombre varchar(256) NOT NULL,
	direccion varchar(256) NOT NULL,
	primary key (rut)
);

CREATE TABLE empleado(
	rut varchar(256) UNIQUE NOT NULL,
	nombre varchar(256) NOT NULL,
	sexo varchar(256),
	domicilio varchar(256),
	prevision_salud varchar(256),
	fecha_nacimiento date,
	numero_telefono varchar(256),
	ref_departamento varchar(256),
	eliminado int DEFAULT '1',
	primary key (rut),
	foreign key (ref_departamento) REFERENCES departamento(direccion) ON DELETE CASCADE
);

CREATE TABLE supervisor(
	ref_empleado varchar(256) NOT NULL,
	primary key (ref_empleado),
	foreign key (ref_empleado) REFERENCES empleado(rut) ON DELETE CASCADE
);

CREATE TABLE repartidor(
	ref_empleado varchar(256) NOT NULL,
	comuna varchar(256),
	primary key (ref_empleado),
	foreign key (ref_empleado) REFERENCES empleado(rut) ON DELETE CASCADE
);

CREATE TABLE bodeguero(
	ref_empleado varchar(256) NOT NULL,
	primary key (ref_empleado),
	foreign key (ref_empleado) REFERENCES empleado(rut) ON DELETE CASCADE
);

CREATE TABLE distribuidor(
	ref_empleado varchar(256) NOT NULL,
	primary key (ref_empleado),
	foreign key (ref_empleado) REFERENCES empleado(rut) ON DELETE CASCADE
);

CREATE TABLE recepcionista(
	ref_empleado varchar(256) NOT NULL,
	primary key (ref_empleado),
	foreign key (ref_empleado) REFERENCES empleado(rut) ON DELETE CASCADE
);

CREATE TABLE cajero(
	ref_empleado varchar(256) NOT NULL,
	eliminado int  DEFAULT '1',
	primary key (ref_empleado),
	foreign key (ref_empleado) REFERENCES empleado(rut) ON DELETE CASCADE
);

CREATE TABLE familiar(
	nombre varchar(256) NOT NULL,
	numero varchar(256) NOT NULL,
	ref_repartidor varchar(256),
	primary key (numero, ref_repartidor),
	foreign key (ref_repartidor) REFERENCES repartidor(ref_empleado) ON DELETE CASCADE

);

CREATE TABLE pago(
	numero_transaccion integer UNIQUE NOT NULL,
	ref_cajero varchar(256) NOT NULL,
	ref_cliente varchar(256) NOT NULL,
	primary key (numero_transaccion),
	foreign key (ref_cajero) REFERENCES cajero(ref_empleado) ON DELETE CASCADE,
	foreign key (ref_cliente) REFERENCES cliente(rut) ON DELETE CASCADE
);

CREATE TABLE efectivo(
	numero_serie varchar(256) NOT NULL,
	ref_pago integer UNIQUE NOT NULL,
	primary key (ref_pago),
	foreign key (ref_pago) REFERENCES pago(numero_transaccion) ON DELETE CASCADE
);

CREATE TABLE credito(
	numero_tarjeta integer NOT NULL,
	numero_cuota integer NOT NULL,
	ref_pago integer UNIQUE NOT NULL,
	primary key (ref_pago),
	foreign key (ref_pago) REFERENCES pago(numero_transaccion) ON DELETE CASCADE

);

CREATE TABLE destinatario(
	rut varchar(256) UNIQUE NOT NULL,
	nombre_pila varchar(256) NOT NULL,
	apellido varchar(256),
	primary key (rut)
);

CREATE TABLE carta(
	codigo integer UNIQUE NOT NULL,
	codigo_postal integer NOT NULL,
	fecha_entrega date NOT NULL,
	nombre_destinatario varchar(256) NOT NULL,
	direccion_destinatario varchar(256),
	ref_departamento varchar(256) NOT NULL,
	ref_repartidor varchar(256) NOT NULL,
	primary key (codigo),
	foreign key (ref_departamento) REFERENCES departamento(direccion) ON DELETE CASCADE,
	foreign key (ref_repartidor) REFERENCES repartidor(ref_empleado) ON DELETE CASCADE
);

CREATE TABLE carta_destinatario(
	firma varchar(256) ,
	fecha_entrega date ,
	ref_destinatario varchar(256),
	ref_carta integer,
	primary key (ref_destinatario,ref_carta),
	foreign key (ref_destinatario) REFERENCES destinatario(rut) ON DELETE CASCADE,
	foreign key (ref_carta) REFERENCES carta(codigo) ON DELETE CASCADE
);


CREATE TABLE supervisor_departamento(
	ref_supervisado varchar(256) NOT NULL,
	ref_departamento varchar(256) NOT NULL,
	primary key (ref_supervisado,ref_departamento),
	foreign key (ref_supervisado) REFERENCES supervisor(ref_empleado) ON DELETE CASCADE,
	foreign key (ref_departamento) REFERENCES departamento(direccion) ON DELETE CASCADE
);