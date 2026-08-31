Imports System
Module codificador_de_mensajes
    Sub Main(args As String())
        Dim ids(9) As Integer
        Dim remitentes(9) As String
        Dim mensajesOriginales(9) As String
        Dim mensajesCodificados(9) As String
        Dim claves(9) As Integer
        Dim estados(9) As String
        Dim cantidad As Integer = 0
        Dim opcion As Integer
        '--------------------------------------------'
        '--|menu_principal_codificador_de_mensajes|--'
        '--------------------------------------------'
        Do
            Console.WriteLine("menu principal codificador de mensajes")
            Console.WriteLine("1) Registrar mensaje")
            Console.WriteLine("2) Editar mensaje")
            Console.WriteLine("3) Listar mensajes")
            Console.WriteLine("4) Buscar mensaje")
            Console.WriteLine("5) Eliminar mensaje")
            Console.WriteLine("6) Decodificar mensaje")
            Console.WriteLine("7) Salir")
            Console.Write("Seleccione una opcion: ")
            opcion = Convert.ToInt32(Console.ReadLine())
            Select Case opcion
                '-----------------------'
                '--|registrar_mensaje|--'
                '-----------------------'
                Case 1
                    If cantidad >= ids.Length Then
                        Console.WriteLine("No hay espacio para registrar mas mensajes.")
                    Else
                        ids(cantidad) = cantidad + 1
                        Console.Write("Remitente: ")
                        remitentes(cantidad) = Console.ReadLine()
                        Console.Write("Mensaje: ")
                        mensajesOriginales(cantidad) = Console.ReadLine()
                        Console.Write("Clave numerica: ")
                        claves(cantidad) = Convert.ToInt32(Console.ReadLine())
                        mensajesCodificados(cantidad) = CodificarMensaje(mensajesOriginales(cantidad), claves(cantidad))
                        estados(cantidad) = "Codificado"
                        cantidad += 1
                        Console.WriteLine("Mensaje registrado y codificado correctamente.")
                        Console.WriteLine("ID: " & ids(cantidad - 1) & " | Remitente: " & remitentes(cantidad - 1) & " | Original: " & mensajesOriginales(cantidad - 1) & " | Codificado: " & mensajesCodificados(cantidad - 1) & " | Clave: " & claves(cantidad - 1) & " | Estado: " & estados(cantidad - 1))
                    End If
                '--------------------'
                '--|editar_mensaje|--'
                '--------------------'
                Case 2
                    If cantidad = 0 Then
                        Console.WriteLine("No existen mensajes registrados.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Remitente: " & remitentes(i) & " | Original: " & mensajesOriginales(i) & " | Codificado: " & mensajesCodificados(i) & " | Clave: " & claves(i) & " | Estado: " & estados(i))
                        Next
                        Console.Write("Ingrese el ID del mensaje a editar: ")
                        Dim idEditar As Integer = Convert.ToInt32(Console.ReadLine())
                        If idEditar >= 1 And idEditar <= cantidad Then
                            Dim posicion As Integer = idEditar - 1
                            Console.Write("Nuevo remitente: ")
                            remitentes(posicion) = Console.ReadLine()
                            Console.Write("Nuevo mensaje: ")
                            mensajesOriginales(posicion) = Console.ReadLine()
                            Console.Write("Nueva clave numerica: ")
                            claves(posicion) = Convert.ToInt32(Console.ReadLine())
                            mensajesCodificados(posicion) = CodificarMensaje(mensajesOriginales(posicion), claves(posicion))
                            estados(posicion) = "Codificado"
                            Console.WriteLine("Mensaje actualizado correctamente.")
                            Console.WriteLine("ID: " & ids(posicion) & " | Remitente: " & remitentes(posicion) & " | Original: " & mensajesOriginales(posicion) & " | Codificado: " & mensajesCodificados(posicion) & " | Clave: " & claves(posicion) & " | Estado: " & estados(posicion))
                        Else
                            Console.WriteLine("ID no encontrada.")
                        End If
                    End If
                '---------------------'
                '--|listar_mensajes|--'
                '---------------------'
                Case 3
                    If cantidad = 0 Then
                        Console.WriteLine("No existen mensajes registrados.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Remitente: " & remitentes(i) & " | Original: " & mensajesOriginales(i) & " | Codificado: " & mensajesCodificados(i) & " | Clave: " & claves(i) & " | Estado: " & estados(i))
                        Next
                    End If
                '--------------------'
                '--|buscar_mensaje|--'
                '--------------------'
                Case 4
                    If cantidad = 0 Then
                        Console.WriteLine("No existen mensajes registrados.")
                    Else
                        Console.WriteLine("1) Buscar por ID")
                        Console.WriteLine("2) Buscar por remitente")
                        Console.Write("Seleccione una opcion: ")
                        Dim tipoBusqueda As Integer = Convert.ToInt32(Console.ReadLine())
                        If tipoBusqueda = 1 Then
                            Console.Write("Ingrese el ID del mensaje a buscar: ")
                            Dim idBuscar As Integer = Convert.ToInt32(Console.ReadLine())
                            If idBuscar >= 1 And idBuscar <= cantidad Then
                                Dim posicion As Integer = idBuscar - 1
                                Console.WriteLine("ID: " & ids(posicion) & " | Remitente: " & remitentes(posicion) & " | Original: " & mensajesOriginales(posicion) & " | Codificado: " & mensajesCodificados(posicion) & " | Clave: " & claves(posicion) & " | Estado: " & estados(posicion))
                            Else
                                Console.WriteLine("ID no encontrada.")
                            End If
                        ElseIf tipoBusqueda = 2 Then
                            Console.Write("Ingrese el remitente: ")
                            Dim remitenteBuscar As String = Console.ReadLine()
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If remitentes(i).ToLower() = remitenteBuscar.ToLower() Then
                                    Console.WriteLine("ID: " & ids(i) & " | Remitente: " & remitentes(i) & " | Original: " & mensajesOriginales(i) & " | Codificado: " & mensajesCodificados(i) & " | Clave: " & claves(i) & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If Not encontrado Then
                                Console.WriteLine("No se encontraron mensajes de ese remitente.")
                            End If
                        Else
                            Console.WriteLine("Opcion no valida.")
                        End If
                    End If
                '----------------------'
                '--|eliminar_mensaje|--'
                '----------------------'
                Case 5
                    If cantidad = 0 Then
                        Console.WriteLine("No existen mensajes registrados.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Remitente: " & remitentes(i) & " | Original: " & mensajesOriginales(i) & " | Codificado: " & mensajesCodificados(i) & " | Clave: " & claves(i) & " | Estado: " & estados(i))
                        Next
                        Console.Write("Ingrese el ID del mensaje a eliminar: ")
                        Dim idEliminar As Integer = Convert.ToInt32(Console.ReadLine())
                        If idEliminar >= 1 And idEliminar <= cantidad Then
                            Dim posicion As Integer = idEliminar - 1
                            For i As Integer = posicion To cantidad - 2
                                ids(i) = ids(i + 1)
                                remitentes(i) = remitentes(i + 1)
                                mensajesOriginales(i) = mensajesOriginales(i + 1)
                                mensajesCodificados(i) = mensajesCodificados(i + 1)
                                claves(i) = claves(i + 1)
                                estados(i) = estados(i + 1)
                            Next
                            cantidad -= 1
                            ids(cantidad) = 0
                            remitentes(cantidad) = ""
                            mensajesOriginales(cantidad) = ""
                            mensajesCodificados(cantidad) = ""
                            claves(cantidad) = 0
                            estados(cantidad) = ""
                            For i As Integer = 0 To cantidad - 1
                                ids(i) = i + 1
                            Next
                            Console.WriteLine("Mensaje eliminado correctamente.")
                        Else
                            Console.WriteLine("ID no encontrada.")
                        End If
                    End If
                '-------------------------'
                '--|decodificar_mensaje|--'
                '-------------------------'
                Case 6
                    If cantidad = 0 Then
                        Console.WriteLine("No existen mensajes registrados.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Remitente: " & remitentes(i) & " | Codificado: " & mensajesCodificados(i) & " | Clave: " & claves(i) & " | Estado: " & estados(i))
                        Next
                        Console.Write("Ingrese el ID del mensaje a decodificar: ")
                        Dim idDecodificar As Integer = Convert.ToInt32(Console.ReadLine())
                        If idDecodificar >= 1 And idDecodificar <= cantidad Then
                            Dim posicion As Integer = idDecodificar - 1
                            Dim mensajeDecodificado As String = DecodificarMensaje(mensajesCodificados(posicion), claves(posicion))
                            Console.WriteLine("ID: " & ids(posicion) & " | Remitente: " & remitentes(posicion) & " | Codificado: " & mensajesCodificados(posicion) & " | Clave: " & claves(posicion) & " | Decodificado: " & mensajeDecodificado)
                        Else
                            Console.WriteLine("ID no encontrada.")
                        End If
                    End If
                '------------------------------'
                '--|salir_del_menu_principal|--'
                '------------------------------'
                Case 7
                    Console.WriteLine("Gracias por utilizar Codificador de Mensajes.")
                Case Else
                    Console.WriteLine("Opcion no valida.")
            End Select
        Loop While opcion <> 7
    End Sub
    '-------------------------------'
    '--|funcion_codificar_mensaje|--'
    '-------------------------------'
    Function CodificarMensaje(mensaje As String, clave As Integer) As String
        Dim resultado As String = ""
        For Each caracter As Char In mensaje
            If Char.IsLetter(caracter) Then
                Dim base As Integer
                If Char.IsUpper(caracter) Then
                    base = Asc("A"c)
                Else
                    base = Asc("a"c)
                End If
                Dim nuevoCaracter As Char = Chr(((Asc(caracter) - base + clave) Mod 26 + 26) Mod 26 + base)
                resultado &= nuevoCaracter
            Else
                resultado &= caracter
            End If
        Next
        Return resultado
    End Function
    Function DecodificarMensaje(mensaje As String, clave As Integer) As String
        Return CodificarMensaje(mensaje, -clave)
    End Function
End Module