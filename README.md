# Tarea_Algoritmo
Un repositorio para la primera tarea de algoritmo.
# Participantes
1. Luis David Herrera Ramírez - 26-ESON-2-001

2. Dauri Alexis Contreras Mora - 26-EISN-2-046

3. Brandhiel Josue Sanchez - 26-ESON-2-013

4. Abdison Azarias Abreu Cruz - 26-ESON-2-005

5. Ruddy Thomas Beras - 26-ESON-2-016

# Descripcion
En este repositorio estará disponible un proyecto programado en C#. El proyecto tendra dos ejercicios:

El primero se trata de un cajero automático, El usuario ingresa un PIN de 4 dígitos (2586), si falla el PIN tres veces el programa se cierra.\
Al poner el PIN correcto Accede a un menú donde podrá ver su saldo, depositar dinero y retirar dinero. El saldo inicial es de RD$10,000.

El ejercicio #2 el cual se trata de integrar o hacer un simulador funcional
del cual se solicita un monto de RD$(5,0000 A 500,000),Plazo (6 a 60 meses y categoria
del socio. si un dato es invalido, se vuelve a pedir la tasa anual de la categoria del socio

Categoria Tasa anual
A 12 %
B 15 %
C 18 %
La cuota fija mensual se calcula con la sigiente formual, donde i es la tasa mensual (Anual÷12) y n el plazo en meses.

Cuota = Monto \cdot \frac{i\,(1+i)^n}{(1+i)^n - 1}                                        

Se muestra la tabla de amortización (cuota, interés, abono a capital y saldo) y los totales pagados.

Se pregunta si desea simular otro préstamo; el programa repite mientras responda "S".

## Datos de Entrada
Menú principal. El usuario ingresa la opción 1, 2 o 3. Es un número entero ( int ) y se valida con int.TryParse.

Ejercicio 1: Cajero automático.

•	El PIN es un texto de 4 dígitos ( string ). Se compara con el PIN definido en el código y el usuario tiene 3 intentos.

•	La opción del menú del cajero, del 1 al 4, es un número entero ( int ) y se valida con int.TryParse.

•	El monto a depositar o retirar es un número decimal ( decimal ). Se valida con decimal.TryParse y luego con las reglas de negocio de cada operación.

Ejercicio 2: Simulador de préstamo.


•	El monto es un número decimal ( decimal ). Se valida con decimal.TryParse y debe estar entre 5,000 y 500,000.

•El plazo en meses es un número entero ( int ). Se valida con int.TryParse y debe estar entre 6 y 60.

•	La categoría del socio es un carácter ( char ). Se valida con char.TryParse y solo se acepta A, B o C.

•	La respuesta a "¿Desea simular otro préstamo?" es un texto ( string ). El programa repite la simulación solo si el usuario responde "S".

En caso de que algún dato sea incorrecto, el programa volverá a solicitar la información (aplica para monto, plazo, categoría y montos del cajero). Si el error ocurre al elegir una opción del menú, se mostrará un mensaje de advertencia.
## Datos que Procesa
•	Validación del PIN, registro de intentos erróneos y bloqueo de la cuenta si se excede el límite.

•	Actualización del saldo tras cada transacción (depósito o retiro), llevando un conteo de las operaciones.

•	Asignación de la tasa de interés anual correspondiente a la categoría del socio.

•	Determinación de la tasa mensual, el cálculo del factor (1 + i)^n y la cuota fija a pagar cada mes.

•	Desglose mensual del crédito: cálculo de intereses, abono al capital y saldo pendiente.

•	Sumatoria de los montos totales pagados y de los intereses acumulados.
## Datos de Salida
Aqui va el texto
## Tecnología Utilizada
Aqui va el texto
# Capturas
## Ejercicio 1
<img width="400" height="225" alt="F1tl" src="https://github.com/user-attachments/assets/00996af5-6b4b-4810-bdd9-5e299da1ff30" />
<img width="400" height="225" alt="F2" src="https://github.com/user-attachments/assets/8f3f95a5-3dda-4c35-a14c-281530ff1465" />
<img width="400" height="225" alt="F3" src="https://github.com/user-attachments/assets/b269716f-fda4-4147-9759-3bde4f8a5f00" />
<img width="400" height="225" alt="F4" src="https://github.com/user-attachments/assets/8639b8be-720a-4236-a880-70499a55df85" />
<img width="400" height="225" alt="F5" src="https://github.com/user-attachments/assets/3b16b150-855e-49ac-aafd-cc4d73530ac0" />
 
## Ejercicio 2
<img width="400" height="225" alt="2F" src="https://github.com/user-attachments/assets/4ea75239-e6d8-4d66-a3ce-8e5fd059532b" />
<img width="800" height="450" alt="2F1" src="https://github.com/user-attachments/assets/acee12c9-a94b-49d3-a9b4-fc1d8c462e80" />




