using System;
using System.Linq;

bool Salir = false;
char eleccion;
string name;
string groupname;
string leer;
string id;
string borrar;

do
{
    Opciones();
    Eleccion();

    switch (eleccion)
    {
        case '1':
            Console.WriteLine("Crear Departamento");
            Crear();
            break;
        case '2':
            Console.WriteLine("Leer Departamento");
            Leer();
            break;
        case '3':
            Console.WriteLine("Modificar Departamento");
            Editar();
            break;
        case '4':
            Console.WriteLine("Borrar Departamento");
            Borrar();
            break;
        case '5':
            Console.WriteLine("Cerrando programa");
            Salir = true;
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }

} while (!Salir);

void Opciones()
{
    Console.WriteLine("");
    Console.WriteLine("Departamento de RRHH");
    Console.WriteLine("--------------------");
    Console.WriteLine("1.- CREAR");
    Console.WriteLine("2.- LEER");
    Console.WriteLine("3.- MODIFICAR");
    Console.WriteLine("4.- BORRAR");
    Console.WriteLine("5.- SALIR");
    Console.WriteLine("--------------------");
    Console.WriteLine("");
    Console.WriteLine("Elige una opción");
}

void Eleccion()
{
    eleccion = (char)Console.Read();
    Console.ReadLine();
}

void Crear()
{
    try
    {
        using (var db = new Practicas36.DepartamentoRecur())
        {
            Console.WriteLine("Nombre departamento:");
            name = Console.ReadLine();
            Console.WriteLine("Grupo departamento");
            groupname = Console.ReadLine();

            db.Departments.Add(new Practicas36.Department() { Name = name, GroupName = groupname});
            db.SaveChanges();
            Console.WriteLine("Departamento creado con éxito");
        }
    } catch (IOException ex)
    {
        Console.WriteLine(ex);
    }
}

void Leer()
{
    try
    {
        using (var db = new Practicas36.DepartamentoRecur())
        {
            Console.WriteLine("1.- Id específica");
            Console.WriteLine("2.- Listar todos ");
            leer = Console.ReadLine();
            if (leer == "1")
            {
                try
                {
                    Console.WriteLine("Introduzca una ID");
                    id = Console.ReadLine();
                    var dep = db.Departments.AsEnumerable().ElementAt(Int32.Parse(id) - 1);
                    Console.WriteLine(dep.DepartmentId.ToString() + " " + dep.Name + " " + dep.GroupName + " " + dep.ModifiedDate);
                } catch (Exception ex)
                {
                    Console.WriteLine("Departamento no encontrado");
                }
            } else if (leer == "2")
            {
                db.Departments.ToList().ForEach(dep1 => Console.WriteLine(dep1.DepartmentId.ToString() + " " + dep1.Name + " " + dep1.GroupName + " " + dep1.ModifiedDate));
            } else
            {
                Console.WriteLine("Valor introducido no valido");
            }
        }
    }
    catch (IOException ex)
    {
        Console.WriteLine(ex);
    }
}

void Editar()
{
    try
    {
        using (var db = new Practicas36.DepartamentoRecur())
        {
            Console.WriteLine("Introduzca una ID");
            id = Console.ReadLine();
            var dep = db.Departments.AsEnumerable().ElementAt(Int32.Parse(id) - 1);
            Console.WriteLine(dep.DepartmentId.ToString() + " " + dep.Name + " " + dep.GroupName + " " + dep.ModifiedDate);

            Console.WriteLine("Modificaciones: ");
            Console.WriteLine("Nombre de departamento");
            dep.Name = Console.ReadLine();
            Console.WriteLine("Grupo Departamento");
            dep.GroupName = Console.ReadLine();

            db.SaveChanges();
            Console.WriteLine("Departamento de id "+ id +" editado con éxito");
        }
    }
    catch (IOException ex)
    {
        Console.WriteLine(ex);
    }
}

void Borrar()
{   
    try {
        using (var db = new Practicas36.DepartamentoRecur())
        {
            Console.WriteLine("Introduzca una ID");
            id = Console.ReadLine();
            var dep = db.Departments.AsEnumerable().ElementAt(Int32.Parse(id) - 1);
            Console.WriteLine(dep.DepartmentId.ToString() + " " + dep.Name + " " + dep.GroupName + " " + dep.ModifiedDate);

            Console.WriteLine("¿ Desea borrar este Departamento ?");
            Console.WriteLine("1.- Si");
            Console.WriteLine("2.- No");
            borrar = Console.ReadLine();

            if (borrar == "1")
            {
                db.Remove(dep);
                db.SaveChanges();
                Console.WriteLine("Departamento borrado correctamente");
            } else if (borrar == "2")
            {
                Console.WriteLine("Operación cancelada");
            }
        }
    }
        catch (IOException ex)
    {
        Console.WriteLine(ex);
    }
}
