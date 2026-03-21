# Tarea: Implementar funcionalidad Windows Forms — AdventureAdmin

## Pasos faltantes

- Hacer Fork 
- Clonar el fork
- Hacer el branch `git checkout -b issue/13_location`
- Opcional  hacer el merge `git fetch; git merge origin/master`

## Objetivo

Implementar la pantalla de lista y el formulario de creacion para una entidad asignada,
siguiendo el patron de la funcionalidad `Product`.

---

## Patron de referencia — directorio `Product`

```
AdventureAdmin.Ui/
+-- Product/
    +-- ProductList.cs       <- Form con DataGridView + boton "Nuevo"
    +-- ProductForm.cs       <- Form con campos, validacion y guardado
```

Tambien se modifican estos archivos existentes:

| Archivo       | Que agregar                                   |
|---------------|-----------------------------------------------|
| `Program.cs`  | Registrar los dos nuevos Forms en el DI       |
| `MainForm.cs` | Conectar el ToolStripMenuItem asignado        |

---

## Entidades asignadas

| #  | Nombre                           | Entidad              | MenuItem en MainForm                  |
|----|----------------------------------|----------------------|---------------------------------------|
| 1  | Cristopher Paulino Burgos        | `Currency`           | `currencyToolStripMenuItem`           |
| 2  | Gustavo Junior Bonifacio Peña    | `Department`         | `departmentToolStripMenuItem`         |
| 3  | Emmanuel Emilio Comery Valdez    | `Shift`              | `shiftToolStripMenuItem`              |
| 4  | Jason Daniel Disla Tejada        | `CountryRegion`      | `countryRegionToolStripMenuItem`      |
| 5  | Jose Julian Martinez Polanco     | `ShipMethod`         | `shipMethodToolStripMenuItem`         |
| 6  | Joseph Leandro Goris Sosa        | `PhoneNumberType`    | `phoneNumberTypeToolStripMenuItem`    |
| 7  | Juana Jael Gomez Bruno           | `ProductDescription` | `productDescriptionToolStripMenuItem` |
| 8  | Mariela Garcia Tejada            | `AddressType`        | `addressTypeToolStripMenuItem`        |
| 9  | Randy Joel Acosta Tejada         | `BusinessEntity`     | `businessEntityToolStripMenuItem`     |
| 10 | Rode Esther Amparo Dishmey       | `Location`           | `locationToolStripMenuItem`           |
| 11 | Winiffer Angelica Hernandez Garcia | `SpecialOffer`     | `specialOfferToolStripMenuItem`       |
| 12 | Yefrailyn Fernandez Nuñez        | `ProductCategory`    | `productCategoryToolStripMenuItem`    |
| 13 | Diana Carolina Hidalgo           | `Culture`            | `cultureToolStripMenuItem`            |
| 14 | Elier Onil Nuñez Peña            | `Person`             | `personToolStripMenuItem`             |
| 15 | Julio Cesar Ortiz Galvez         | `CreditCard`         | `creditCardToolStripMenuItem`         |
| 16 | Leander Alfonso Valdez Reyes     | `ContactType`        | `contactTypeToolStripMenuItem`        |
| 17 | Marcos Miguel Gomez Camilo       | `ScrapReason`        | `scrapReasonToolStripMenuItem`        |

---

## Paso 1 — Fork y Clone

1. Ir a https://github.com/enelramon/AdventureAdmin
2. Clic en **Fork** (esquina superior derecha) — el repo se copia a tu cuenta
3. Clonar tu fork localmente (reemplaza TU_USUARIO):

```
git clone https://github.com/TU_USUARIO/AdventureAdmin.git
cd AdventureAdmin
```

---

## Paso 2 — Implementar la funcionalidad

Crear la carpeta `AdventureAdmin.Ui/[Entidad]/` y dentro dos Windows Forms:

**`[Entidad]List.cs`** — igual a `ProductList.cs`: carga registros en un DataGridView y abre el form de creacion.

**`[Entidad]Form.cs`** — igual a `ProductForm.cs`: campos para ingresar datos, validacion con ErrorProvider y boton guardar.

Luego modificar los dos archivos existentes:

**`Program.cs`** — registrar los forms en el contenedor DI:

```csharp
services.AddTransient<[Entidad]List>();
services.AddTransient<[Entidad]Form>();
```

**`MainForm.cs`** — conectar el menu item asignado:

```csharp
private void [entidad]ToolStripMenuItem_Click(object sender, EventArgs e)
{
    var form = Program.ServiceProvider.GetRequiredService<[Entidad]List>();
    form.Show();
}
```

---

## Paso 3 — Commit y Push

```
git add .
git commit -m "feat: agregar [Entidad]List y [Entidad]Form"
git push origin master
```

---

## Paso 4 — Pull Request

1. Ir a tu repositorio en GitHub: https://github.com/TU_USUARIO/AdventureAdmin
2. Clic en **"Compare & pull request"**
3. Completar el formulario:
   - **Titulo:** feat: [Entidad] - Nombre Apellido
   - **Descripcion:** que entidad implementaste y que hace cada form
4. Clic en **"Create pull request"**

---

## Criterios de evaluacion

| Criterio                                                              | Puntos   |
|-----------------------------------------------------------------------|----------|
| `[Entidad]List.cs` carga y muestra datos en el DataGridView           | 30 pts   |
| `[Entidad]Form.cs` guarda un nuevo registro correctamente             | 40 pts   |
| DI registrado en `Program.cs` y menu conectado en `MainForm.cs`       | 20 pts   |
| Mensaje de commit descriptivo y PR con titulo correcto                | 10 pts   |
| **Total**                                                             | **100**  |
