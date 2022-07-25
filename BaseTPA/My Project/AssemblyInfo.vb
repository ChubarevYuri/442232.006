Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' Общие сведения об этой сборке предоставляются следующим набором
' атрибутов. Отредактируйте значения этих атрибутов, чтобы изменить
' общие сведения об этой сборке.

' Проверьте значения атрибутов сборки

<Assembly: AssemblyTitle("BaseTPA")>
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyCompany("")>
<Assembly: AssemblyProduct("BaseTPA")>
<Assembly: AssemblyCopyright("Copyright ©  2022")>
<Assembly: AssemblyTrademark("")>

<Assembly: CLSCompliant(True)>

<Assembly: ComVisible(False)>

'Следующий GUID служит для идентификации библиотеки типов, если этот проект будет видимым для COM
<Assembly: Guid("3fc3c231-7922-4152-aa89-47abfe6d9743")>

' Сведения о версии сборки состоят из следующих четырех значений:
'
'      Основной номер версии
'      Дополнительный номер версии
'      Номер построения
'      Редакция
'
' Можно задать все значения или принять номер построения и номер редакции по умолчанию,
' используя "*", как показано ниже:
' <Assembly: AssemblyVersion("1.0.*")>

<Assembly: AssemblyVersion("1.0.0.0")>

'Следующий атрибут служит для подавления предупреждения FxCop "CA2232: Microsoft.Usage: добавьте к сборке STAThreadAttribute",
' так как приложение для устройства не поддерживает поток STA.
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2232:MarkWindowsFormsEntryPointsWithStaThread")>
