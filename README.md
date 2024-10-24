# C# 10 without OOP - Practice

## Gestión de cuenta bancaria mono-usuario (Versión 1)

El programa mostrará un menú con las siguientes opciones:

1. **Money income**: Permite ingresar dinero en la cuenta.
2. **Money outcome**: Permite retirar dinero de la cuenta.
3. **List all movements**: Muestra todos los movimientos de ingresos y retiros realizados.
4. **List incomes**: Muestra todos los ingresos registrados.
5. **List outcomes**: Muestra todos los retiros registrados.
6. **Show current money**: Muestra el saldo actual de la cuenta.
7. **Exit**: Sale del programa.

## Gestión de cuenta bancaria mono-usuario (Versión 1)

- Existirá una variable que guardará el saldo de un único cliente y sobre ese saldo se realizarán los ingresos (sumas de dinero al saldo actual) o retiradas (restas de dinero al saldo actual) de efectivo.
- Una vez finalizada cualquier operación, el programa preguntará al usuario si desea realizar otra operación:
  - Si el usuario responde que **sí**, se volverá a mostrar el menú esperando una nueva opción.
  - En caso contrario mostrará el valor actual de saldo y finalizará el programa.

## Gestión de cuenta bancaria multi-usuario (Versión 2)

- Antes de mostrar ningún menú de opciones, el programa pedirá al cliente introducir un número de cuenta y un pin

- Existirá una lista con números de cuenta y otra con pines, de tal forma que el inésimo número de cuenta de la primera lista tendrá asociado el i-ésimo pin de la segunda lista.
  
## Gestión de cuenta bancaria multi-usuario (Versión 2)

- La información del saldo y los movimientos del cliente de la versión 1, aquí estarán incluidos en listas que, igual que para el pin, contendrán en su elemento i-ésimo la información del cliente que en la lista de números de cuenta tenga su número de cuenta en esa misma posición
  
- El programa comprobará si el número de cuenta y el pin introducidos por el cliente existen y están en la misma posición (llamémosla i) para las dos listas correspondientes, y solo en ese caso se permitirá seguir igual que la versión 1, considerando que la información de saldo y movimientos a consultar o modificar se obtendrán de la posición i de las listas correspondientes


