Public Class cartaTakeway

    ' CartaOnline ' ----- ' Version: alpha 1.0 '  ------ ' 16/5/2022 ' ----- ' Lorenzatti Nazareno , Abreu Rondon Brayean' ----- 

    '---------------------'nl.loragro@gmail.com '   --------------- ' brayeanrabreu@gmail.com '---------------------------------

    '<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< TEO 1 - PROGRAMACION VISUAL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


    'variables globales'
    Dim precios(33) As Double
    Dim tiempos(33) As Double
    Dim cantidades(33) As Double
    Dim costo_Envio As Double
    Dim costo_Total, demora_Total, demora_Minutos, demora_Horas, costo_Comida, costo_Bebida, costo_TotalAux, demora_HorasAux, demora_MinutosAux As Double
    Dim dirEnvio As String




    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        End
    End Sub 'Boton Cerrar Aplicacion'

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        'Cuando el usuario le da click al boton de limpiar reseteo todo el formulario'

        txtCostoBebida.Text = ""
        txtCostoComida.Text = ""
        txtCostoEnvio.Text = ""
        txtCostoTotal.Text = ""
        txtDemora.Text = ""
        txtDireccion.Text = ""

        chkBoxAgridulce.Checked = False
        chkBoxArosCeb.Checked = False
        chkBoxBañacauda.Checked = False
        chkBoxBondiola.Checked = False
        chkBoxCervezas.Checked = False
        chkBoxChedar.Checked = False
        chkBoxCornalitos.Checked = False
        chkBoxCuatroQuesos.Checked = False
        chkBoxEspecial.Checked = False
        chkBoxFernet.Checked = False
        chkBoxGaseosas.Checked = False
        chkBoxHamburguesa.Checked = False
        chkBoxHamCompleta.Checked = False
        chkBoxHamDoble.Checked = False
        chkBoxLomito.Checked = False
        chkBoxMuza.Checked = False
        chkBoxPaella.Checked = False
        chkBoxPapas.Checked = False
        chkBoxPicFiambres.Checked = False
        chkBoxPicRebozados.Checked = False
        chkBoxRabas.Checked = False
        chkBoxRavioles.Checked = False
        chkBoxRucula.Checked = False
        chkBoxSalCriolla.Checked = False
        chkBoxSalTartara.Checked = False
        chkBoxSandMilanesa.Checked = False
        chkBoxTragos.Checked = False
        chkBoxVacio.Checked = False
        chkBoxVegano.Checked = False
        chkBoxVerdeo.Checked = False
        chkBoxVinos.Checked = False
        chkBoxWacamole.Checked = False
        chkBoxWhiski.Checked = False

        radBtnCancPedido.Checked = False
        radBtnEnvio.Checked = False
        radBtnRetiro.Checked = True
        txtDireccion.Enabled = False
        txtDireccion.BackColor = Color.LemonChiffon
        radBtnSinAdere.Checked = False

        Panel1.Enabled = False



    End Sub 'Boton Limpiar cuestionario'

    Private Sub btnPedir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPedir.Click



        ' tiempo en minutos y precio en pesos '
        ' Todo estos calculos ocurren cuando el usuario le da click al boton de pedir'

        'Voy guardando los precios en el Array tomando el valor que contengan los textbox donde escribo los precios, para que sea sencillo actualizarlo'
        'Utilizo un bucle for Each por cada Group Box para un mayor control, y para evitar errores si no los tengo separados por GroupBox'

        '--------------------------------------------------------------------------------------------------------------------------------------'

        'COMIDAS AL PLATO'
        Dim cont As Integer = 0
        For Each TextBox As Control In GroupBox1.Controls
            If TypeOf TextBox Is TextBox Then
                precios(cont) = GroupBox1.Controls("txtPrecio" & cont).Text
                cont += 1
            End If
        Next

        '--------------------------------------------------------------------------------------------------------------------------------------'

        'PIZZAS'

        Dim cont1 As Integer = 5
        For Each TextBox As Control In GroupBox2.Controls
            If TypeOf TextBox Is TextBox Then
                precios(cont1) = GroupBox2.Controls("txtPrecio" & cont1).Text
                cont1 += 1
            End If

        Next

        '--------------------------------------------------------------------------------------------------------------------------------------'

        'SANDWICHES'

        Dim cont2 As Integer = 10
        For Each TextBox As Control In GroupBox3.Controls
            If TypeOf TextBox Is TextBox Then
                precios(cont2) = GroupBox3.Controls("txtPrecio" & cont2).Text
                cont2 += 1
            End If

        Next

        '--------------------------------------------------------------------------------------------------------------------------------------'

        'ENTRADAS'

        Dim cont3 As Integer = 16
        For Each TextBox As Control In GroupBox4.Controls
            If TypeOf TextBox Is TextBox Then
                precios(cont3) = GroupBox4.Controls("txtPrecio" & cont3).Text
                cont3 += 1
            End If

        Next

        '--------------------------------------------------------------------------------------------------------------------------------------'

        'BEBIDAS'

        Dim cont4 As Integer = 22
        For Each TextBox As Control In GroupBox5.Controls
            If TypeOf TextBox Is TextBox Then
                precios(cont4) = GroupBox5.Controls("txtPrecio" & cont4).Text
                cont4 += 1
            End If

        Next

        '--------------------------------------------------------------------------------------------------------------------------------------'

        'ADEREZOS'

        Dim cont5 As Integer = 28
        For Each TextBox As Control In GroupBox6.Controls
            If TypeOf TextBox Is TextBox Then
                precios(cont5) = GroupBox6.Controls("txtPrecio" & cont5).Text
                cont5 += 1
            End If

        Next

        '--------------------------------------------------------------------------------------------------------------------------------------'

        ' Guardo en un array las cantidades guardadas en los text box del formulario, para poder calcular el costo total, cada indice corresponde a cada comida'

        Dim ñ As Integer = 0

        For Each txtCantidad As Control In Panel2.Controls
            If TypeOf txtCantidad Is TextBox Then
                cantidades(ñ) = Panel2.Controls("txtCantidad" & ñ).Text
                ñ += 1
            End If
        Next


        ' comienzo la comprobacion de los check box y de acuerdo al que este seleccionado voy sumando el precio y el tiempo de demora del pedido

        '--------------------------------------------------------------------------------------------------------------------------------------'

        'COMIDAS AL PLATO'

        ' hay que tener en cuenta que comienza a comprobar los check box de abajo hacia arriba '


        Dim contador As Integer = 0
        Dim cant As Integer = 1
        For Each control As Control In GroupBox1.Controls
            If TypeOf control Is CheckBox Then
                If TryCast(control, CheckBox).Checked = True Then
                    costo_Comida = calcularCosto(costo_Comida, precios(contador), cantidades(contador))
                    Select Case cant                                                         ' el selec case va contando la cantidad de comidas que se '
                        Case 1                                                               ' eligieron de ese grupo de comida y va sumando el tiempo exponencialmente'
                            demora_Total = calcularDemora(demora_Total, tiempos(contador))   ' ya que el tiempo de elaboracion no es siempre directo por lo q se establece un calculo'
                        Case 2
                            demora_Total += tiempos(contador) * 0.35
                        Case 3 To 5
                            demora_Total += tiempos(contador) * 0.05
                    End Select
                    cant += 1
                    contador += 1
                Else
                    contador += 1
                End If
            End If
        Next

        '--------------------------------------------------------------------------------------------------------------------------------------'
        '  tengo q ir haciendo un ciclo por cada group box para q pueda comprobarse'

        'PIZZAS'
        Dim contador1 As Integer = 5
        For Each control As Control In GroupBox2.Controls
            If TypeOf control Is CheckBox Then
                If TryCast(control, CheckBox).Checked = True Then
                    costo_Comida = calcularCosto(costo_Comida, precios(contador1), cantidades(contador1))
                    Select Case cant
                        Case 1
                            demora_Total = calcularDemora(demora_Total, tiempos(contador1))
                        Case 2
                            demora_Total += tiempos(contador1) * 0.35
                        Case 3 To 5
                            demora_Total += tiempos(contador1) * 0.05
                    End Select
                    cant += 1
                    contador1 += 1
                Else
                    contador1 += 1
                End If
            End If
        Next

        '--------------------------------------------------------------------------------------------------------------------------------------'

        'SANDWICHES'
        Dim contador2 As Integer = 10
        For Each control As Control In GroupBox3.Controls
            If TypeOf control Is CheckBox Then
                If TryCast(control, CheckBox).Checked = True Then
                    costo_Comida = calcularCosto(costo_Comida, precios(contador2), cantidades(contador2))
                    Select Case cant
                        Case 1
                            demora_Total = calcularDemora(demora_Total, tiempos(contador2))
                        Case 2
                            demora_Total += tiempos(contador2) * 0.35
                        Case 3 To 5
                            demora_Total += tiempos(contador2) * 0.05
                    End Select
                    cant += 1
                    contador2 += 1
                Else
                    contador2 += 1
                End If
            End If
        Next

        '--------------------------------------------------------------------------------------------------------------------------------------'

        'ENTRADAS'
        Dim contador3 As Integer = 16
        For Each control As Control In GroupBox4.Controls
            If TypeOf control Is CheckBox Then
                If TryCast(control, CheckBox).Checked = True Then
                    costo_Comida = calcularCosto(costo_Comida, precios(contador3), cantidades(contador3))
                    Select Case cant
                        Case 1
                            demora_Total = calcularDemora(demora_Total, tiempos(contador3))
                        Case 2
                            demora_Total += tiempos(contador3) * 0.35
                        Case 3 To 5
                            demora_Total += tiempos(contador3) * 0.05
                    End Select
                    cant += 1
                    contador3 += 1
                Else
                    contador3 += 1
                End If
            End If
        Next

        '--------------------------------------------------------------------------------------------------------------------------------------'

        'BEBIDAS'
        Dim contador4 As Integer = 22
        For Each control As Control In GroupBox5.Controls
            If TypeOf control Is CheckBox Then
                If TryCast(control, CheckBox).Checked = True Then
                    costo_Bebida = calcularCosto(costo_Bebida, precios(contador4), cantidades(contador4))
                    Select Case cant
                        Case 1
                            demora_Total = calcularDemora(demora_Total, tiempos(contador4))
                        Case 2
                            demora_Total += tiempos(contador4) * 0.35
                        Case 3 To 5
                            demora_Total += tiempos(contador4) * 0.05
                    End Select
                    cant += 1
                    contador4 += 1
                Else
                    contador4 += 1
                End If
            End If
        Next

        '--------------------------------------------------------------------------------------------------------------------------------------'

        'ADEREZOS'
        Dim contador5 As Integer = 28
        For Each control As Control In GroupBox6.Controls
            If TypeOf control Is CheckBox Then
                If TryCast(control, CheckBox).Checked = True Then
                    costo_Comida = calcularCosto(costo_Comida, precios(contador5), cantidades(contador5))
                    Select Case cant
                        Case 1
                            demora_Total = calcularDemora(demora_Total, tiempos(contador5))
                        Case 2
                            demora_Total += tiempos(contador5) * 0.35
                        Case 3 To 5
                            demora_Total += tiempos(contador5) * 0.05
                    End Select
                    cant += 1
                    contador5 += 1
                Else
                    contador5 += 1
                End If
            End If
        Next

        '-------------------------------------------------------------------------------------------------------------------------------------------------------------'
        'habilito el panel donde se encuentra el boton de pagar y se muestran los montos'
        Panel1.Enabled = True

        ' convierto el tiempo de demora total que estaba en minutos a horas y minutos '

        demora_Horas = Math.Truncate(demora_Total / 60)
        demora_Minutos = Math.Truncate(demora_Total Mod 60)


        'COMPROBACION DE INGRESO DE UNA DIRECCION CORRECTA'
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------'

        If radBtnEnvio.Checked And Len(txtDireccion.Text) = 0 Or txtDireccion.Text = "INGRESE LA DIRECCION DE ENVIO" Then
            ' Si no se ingresa una direccion correcta no permite terminar con el pedido'
            MsgBox("No ingreso ninguna direccion de envio")
            costo_Envio = 0
            Panel1.Enabled = False

            txtCostoBebida.Text = ""
            txtCostoComida.Text = ""
            txtCostoEnvio.Text = ""
            txtCostoTotal.Text = ""
            txtDemora.Text = ""
            txtDireccion.Text = ""

        Else ' si se ingresa una direccion correcta sigue con el pedido'

            txtCostoEnvio.Text = costo_Envio

            ' variable donde se guarda la direccion de envio' en este programa de ejemplo no se utiliza'
            dirEnvio = txtDireccion.Text

            'calculo el costo total que debe pagar el cliente'
            costo_Total = costo_Comida + costo_Bebida + costo_Envio

            'variable auxiliar para facturacion'

            costo_TotalAux = costo_Total
            demora_HorasAux = demora_Horas
            demora_MinutosAux = demora_Minutos

            ' muestro en el formulario el costo total y discriminado para mayor informacio'
            txtCostoComida.Text = costo_Comida
            txtCostoBebida.Text = costo_Bebida
            txtCostoTotal.Text = costo_Total

            'muestro en el formulario cuanto tiempo demorara el pedido que se armo'
            txtDemora.Text = ("Su pedido demorara: " & demora_Horas & " horas y " & demora_Minutos & " minutos")

            'una vez que se calcula el costo del pedido se vuelven las variables a 0 para evitar que se sigan sumando al clickear varias veces al boton pedir'

            costo_Comida = 0
            costo_Bebida = 0
            costo_Envio = 0
            costo_Total = 0
            demora_Horas = 0
            demora_Minutos = 0
            demora_Total = 0

        End If
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------'



    End Sub 'Boton para realizar el pedido '

    Public Function calcularCosto(ByVal costoTotal As Double, ByVal precio As Double, ByVal cantidad As Double) As Double
        Dim costo As Double
        costo = costoTotal + (precio * cantidad)
        Return costo
    End Function ' funcion para calcular costo total '

    Public Function calcularDemora(ByVal demoraTotal As Double, ByVal tiempo As Double) As Double
        Dim demora As Double
        demora = demoraTotal + tiempo
        Return demora
    End Function ' funcion para calcular el tiempo de demora del pedido'


    Private Sub radBtnPedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radBtnPedido.CheckedChanged

        ' Realizo una comprobacion para saber si esta seleccionado el RadioButton hacer pedido, En caso de estarlo'
        ' Habilito todo el formulario para seleccionar las comidas y realizar el pedido '

        Dim ChekPedido As Boolean

        ChekPedido = radBtnPedido.Checked

        If ChekPedido Then
            Panel2.Enabled = True

        End If
    End Sub 'RadioBtn Hacer Pedido que habilita el cuestionario para realizar el pedido'

    Private Sub radBtnCancPedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radBtnCancPedido.CheckedChanged

        ' Realizo una comprobacion para saber si esta seleccionado el RadioButton Cancelar pedido, En caso de estarlo'
        ' deshabilito todo el formulario para seleccionar las comidas por lo que el usuario no podra realizar ningun pedido'

        Dim ChekCanc As Boolean

        ChekCanc = radBtnCancPedido.Checked

        If ChekCanc Then
            Panel2.Enabled = False

        End If
    End Sub 'RadioBtn Cancelar Pedido'

    Private Sub radBtnSinAdere_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radBtnSinAdere.CheckedChanged

        'si el boton sin aderezos esta clickeado se borra la seleccion de aderezos'

        Dim chekSinAderezo, chekConAderezo As Boolean

        chekSinAderezo = radBtnSinAdere.Checked
        chekConAderezo = radBtnConAdere.Checked


        If chekSinAderezo Then
            chkBoxChedar.Checked = False
            chkBoxSalCriolla.Checked = False
            chkBoxSalTartara.Checked = False
            chkBoxVerdeo.Checked = False
            chkBoxWacamole.Checked = False
            chkBoxChedar.Enabled = False
            chkBoxSalCriolla.Enabled = False
            chkBoxSalTartara.Enabled = False
            chkBoxVerdeo.Enabled = False
            chkBoxWacamole.Enabled = False
        End If

        If chekConAderezo Then
            radBtnSinAdere.Checked = False
            chkBoxChedar.Enabled = True
            chkBoxSalCriolla.Enabled = True
            chkBoxSalTartara.Enabled = True
            chkBoxVerdeo.Enabled = True
            chkBoxWacamole.Enabled = True
        End If

    End Sub ' comprobacion Con o sin Aderezos'

    Private Sub btnPagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPagar.Click
        Dim efe, tran, cred, deb As Integer
        Dim tarjCred, tarjDeb As String
        Dim tarjetaCredito, tarjetaDebito As Long

        ' segun el medio de pago que seleccione el cliente se toma su index y de acuerdo a el se solicitan los datos correspondientes'

        
        efe = 0
        cred = 1
        deb = 2
        tran = 3


        If efe = ComboBox1.SelectedIndex Then ' PAGO EN EFECTIVO '
            MsgBox("GRACIAS POR SU COMPRA" & vbNewLine & "Su pedido estara listo en " & demora_HorasAux & " horas y " & demora_MinutosAux & " minutos para su retiro " & vbNewLine & " El monto de su factura es de " & costo_TotalAux & vbNewLine & "Registramos que usted pagara en efectivo al retirar el pedido" & vbNewLine & "Direccion de envio: " & dirEnvio)
        End If

        If tran = ComboBox1.SelectedIndex Then ' PAGO CON TRANSFERENCIA '
            MsgBox("REALICE SU TRANSFERENCIA AL SIGUIENTE CBU " & vbNewLine & "CBU: 0000051239641186213185" & vbNewLine & "CUIL: 20-8422142-1" & vbNewLine & "BANCO: Santander")
            MsgBox("GRACIAS POR SU COMPRA" & vbNewLine & "Su pedido estara listo en " & demora_HorasAux & " horas y " & demora_MinutosAux & " minutos " & vbNewLine & "El monto de su factura es de " & costo_TotalAux & "Registramos su pago a traves de transferencia bancaria" & vbNewLine & "Direccion de envio: " & dirEnvio)
        End If


        If cred = ComboBox1.SelectedIndex Then ' PAGO CON TARJETA DE CREDITO '
            tarjCred = InputBox("Ingrese el numero de su tarjeta", "Pago con tarjeta de credito")
            If tarjCred = "" Then
                MsgBox("Error Ingrese nuevamente")
            Else
                tarjetaCredito = Convert.ToInt64(Val(tarjCred))
                MsgBox("GRACIAS POR SU COMPRA" & vbNewLine & "Su pedido estara listo en " & demora_HorasAux & " horas y " & demora_MinutosAux & " minutos " & vbNewLine & "El monto de su factura es de " & costo_TotalAux & vbNewLine & "Registramos su pago con tarjeta de credito" & vbNewLine & "Direccion de envio: " & dirEnvio)
            End If
        End If

        If deb = ComboBox1.SelectedIndex Then ' PAGO CON TARJETA DE DEBITO '
            tarjDeb = InputBox("Ingrese el numero de su tarjeta", "Pago con tarjeta de Debito")
            If tarjDeb = "" Then
                MsgBox("Error Ingrese nuevamente")
            Else
                tarjetaDebito = Convert.ToInt64(Val(tarjDeb))
                MsgBox("GRACIAS POR SU COMPRA" & vbNewLine & "Su pedido estara listo en " & demora_HorasAux & " horas y " & demora_MinutosAux & " minutos " & vbNewLine & "El monto de su factura es de " & costo_TotalAux & vbNewLine & "Registramos su pago con tarjeta de debito" & vbNewLine & "Direccion de envio: " & dirEnvio)
            End If
        End If

        demora_HorasAux = 0
        demora_MinutosAux = 0
        costo_TotalAux = 0

    End Sub ' Pedido de datos y factura '

    'GENERACIONES AL INICIO DEL FORMULARIO'

    Private Sub cartaTakeway_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        radBtnEnvio.Checked = True

        '--------------------------------------------------------------------------------------------------------------------------------------'
        'genero numeros random para poner como tiempo necesarios para elaborar las comidas, en caso de estar aplicandose en un negocio este programa'
        'los tiempos de cada comida se pondran de acuerdo al tiempo de elaboracion que conlleve cada una'

        Dim i, nrorandom As Integer

        For i = 0 To 32
            Do
                nrorandom = CInt(Rnd() * 100)
            Loop While (nrorandom > 5 And nrorandom < 15)

            If i >= 22 And i <= 27 Then ' Corresponde a la parte de bebidas las cuales no sumarian tiempo al envio'
                tiempos(i) = 0
            Else
                tiempos(i) = nrorandom
            End If
        Next


    End Sub

    'HABILITA O DESHABILITA TEXTBOX DONDE SE INGRESA LA DIRECCION DE ENVIO'

    Private Sub radBtnEnvio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radBtnEnvio.CheckedChanged
        Dim envio, retiro As Boolean

        envio = radBtnEnvio.Checked
        retiro = radBtnRetiro.Checked


        If envio Then
            txtDireccion.Enabled = True
            txtDireccion.BackColor = Color.White
            txtDireccion.Text = "INGRESE LA DIRECCION DE ENVIO"
            costo_Envio = 27
        End If

        If retiro Then
            txtDireccion.Enabled = False
            txtDireccion.BackColor = Color.LemonChiffon
            txtDireccion.Text = ""
            costo_Envio = 0
        End If

    End Sub

    'HABILITA LAS TEXTBOX DONDE SE INGRESAN LAS CANTIDADES DE ACUERDO AL CHECK BOX DE COMIDA QUE ESTE SELECCIONADO EN ESE MOMENTO'

    Private Sub chkBoxBañacauda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxBañacauda.CheckedChanged
        If chkBoxBañacauda.Checked Then
            txtCantidad0.Enabled = True
            txtCantidad0.Visible = True
        Else
            txtCantidad0.Enabled = False
            txtCantidad0.Visible = False
        End If
    End Sub
    Private Sub chkBoxPaella_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxPaella.CheckedChanged
        If chkBoxPaella.Checked Then
            txtCantidad1.Enabled = True
            txtCantidad1.Visible = True
        Else
            txtCantidad1.Enabled = False
            txtCantidad1.Visible = False

        End If
    End Sub
    Private Sub chkBoxRavioles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxRavioles.CheckedChanged
        If chkBoxRavioles.Checked Then
            txtCantidad2.Enabled = True
            txtCantidad2.Visible = True
        Else
            txtCantidad2.Enabled = False
            txtCantidad2.Visible = False

        End If
    End Sub
    Private Sub chkBoxVacio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxVacio.CheckedChanged
        If chkBoxVacio.Checked Then
            txtCantidad3.Enabled = True
            txtCantidad3.Visible = True
        Else
            txtCantidad3.Enabled = False
            txtCantidad3.Visible = False
        End If
    End Sub
    Private Sub chkBoxBondiola_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxBondiola.CheckedChanged
        If chkBoxBondiola.Checked Then
            txtCantidad4.Enabled = True
            txtCantidad4.Visible = True
        Else
            txtCantidad4.Enabled = False
            txtCantidad4.Visible = False
        End If
    End Sub
    Private Sub chkBoxAgridulce_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxAgridulce.CheckedChanged
        If chkBoxAgridulce.Checked Then
            txtCantidad5.Enabled = True
            txtCantidad5.Visible = True
        Else
            txtCantidad5.Enabled = False
            txtCantidad5.Visible = False
        End If
    End Sub
    Private Sub chkBoxRucula_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxRucula.CheckedChanged
        If chkBoxRucula.Checked Then
            txtCantidad6.Enabled = True
            txtCantidad6.Visible = True
        Else
            txtCantidad6.Enabled = False
            txtCantidad6.Visible = False
        End If
    End Sub
    Private Sub chkBoxEspecial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxEspecial.CheckedChanged
        If chkBoxEspecial.Checked Then
            txtCantidad7.Enabled = True
            txtCantidad7.Visible = True
        Else
            txtCantidad7.Enabled = False
            txtCantidad7.Visible = False
        End If
    End Sub
    Private Sub chkBoxCuatroQuesos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxCuatroQuesos.CheckedChanged
        If chkBoxCuatroQuesos.Checked Then
            txtCantidad8.Enabled = True
            txtCantidad8.Visible = True
        Else
            txtCantidad8.Enabled = False
            txtCantidad8.Visible = False
        End If
    End Sub
    Private Sub chkBoxMuza_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxMuza.CheckedChanged
        If chkBoxMuza.Checked Then
            txtCantidad9.Enabled = True
            txtCantidad9.Visible = True
        Else
            txtCantidad9.Enabled = False
            txtCantidad9.Visible = False
        End If
    End Sub
    Private Sub chkBoxVegano_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxVegano.CheckedChanged
        If chkBoxVegano.Checked Then
            txtCantidad10.Enabled = True
            txtCantidad10.Visible = True
        Else
            txtCantidad10.Enabled = False
            txtCantidad10.Visible = False
        End If
    End Sub
    Private Sub chkBoxHamDoble_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxHamDoble.CheckedChanged
        If chkBoxHamDoble.Checked Then
            txtCantidad11.Enabled = True
            txtCantidad11.Visible = True
        Else
            txtCantidad11.Enabled = False
            txtCantidad11.Visible = False
        End If
    End Sub
    Private Sub chkBoxLomito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxLomito.CheckedChanged
        If chkBoxLomito.Checked Then
            txtCantidad12.Enabled = True
            txtCantidad12.Visible = True
        Else
            txtCantidad12.Enabled = False
            txtCantidad12.Visible = False
        End If
    End Sub
    Private Sub chkBoxSandMilanesa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxSandMilanesa.CheckedChanged
        If chkBoxSandMilanesa.Checked Then
            txtCantidad13.Enabled = True
            txtCantidad13.Visible = True
        Else
            txtCantidad13.Enabled = False
            txtCantidad13.Visible = False
        End If
    End Sub
    Private Sub chkBoxHamCompleta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxHamCompleta.CheckedChanged
        If chkBoxHamCompleta.Checked Then
            txtCantidad14.Enabled = True
            txtCantidad14.Visible = True
        Else
            txtCantidad14.Enabled = False
            txtCantidad14.Visible = False
        End If
    End Sub
    Private Sub chkBoxHamburguesa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxHamburguesa.CheckedChanged
        If chkBoxHamburguesa.Checked Then
            txtCantidad15.Enabled = True
            txtCantidad15.Visible = True
        Else
            txtCantidad15.Enabled = False
            txtCantidad15.Visible = False
        End If
    End Sub
    Private Sub chkBoxCornalitos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxCornalitos.CheckedChanged
        If chkBoxCornalitos.Checked Then
            txtCantidad16.Enabled = True
            txtCantidad16.Visible = True
        Else
            txtCantidad16.Enabled = False
            txtCantidad16.Visible = False
        End If
    End Sub
    Private Sub chkBoxArosCeb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxArosCeb.CheckedChanged
        If chkBoxArosCeb.Checked Then
            txtCantidad17.Enabled = True
            txtCantidad17.Visible = True
        Else
            txtCantidad17.Enabled = False
            txtCantidad17.Visible = False
        End If
    End Sub
    Private Sub chkBoxPicFiambres_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxPicFiambres.CheckedChanged
        If chkBoxPicFiambres.Checked Then
            txtCantidad18.Enabled = True
            txtCantidad18.Visible = True
        Else
            txtCantidad18.Enabled = False
            txtCantidad18.Visible = False
        End If
    End Sub
    Private Sub chkBoxPicRebozados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxPicRebozados.CheckedChanged
        If chkBoxPicRebozados.Checked Then
            txtCantidad19.Enabled = True
            txtCantidad19.Visible = True
        Else
            txtCantidad19.Enabled = False
            txtCantidad19.Visible = False
        End If
    End Sub
    Private Sub chkBoxRabas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxRabas.CheckedChanged
        If chkBoxRabas.Checked Then
            txtCantidad20.Enabled = True
            txtCantidad20.Visible = True
        Else
            txtCantidad20.Enabled = False
            txtCantidad20.Visible = False
        End If
    End Sub
    Private Sub chkBoxPapas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxPapas.CheckedChanged
        If chkBoxPapas.Checked Then
            txtCantidad21.Enabled = True
            txtCantidad21.Visible = True
        Else
            txtCantidad21.Enabled = False
            txtCantidad21.Visible = False
        End If
    End Sub
    Private Sub chkBoxFernet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxFernet.CheckedChanged
        If chkBoxFernet.Checked Then
            txtCantidad22.Enabled = True
            txtCantidad22.Visible = True
        Else
            txtCantidad22.Enabled = False
            txtCantidad22.Visible = False
        End If
    End Sub
    Private Sub chkBoxWhiski_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxWhiski.CheckedChanged
        If chkBoxWhiski.Checked Then
            txtCantidad23.Enabled = True
            txtCantidad23.Visible = True
        Else
            txtCantidad23.Enabled = False
            txtCantidad23.Visible = False
        End If
    End Sub
    Private Sub chkBoxTragos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxTragos.CheckedChanged
        If chkBoxTragos.Checked Then
            txtCantidad24.Enabled = True
            txtCantidad24.Visible = True
        Else
            txtCantidad24.Enabled = False
            txtCantidad24.Visible = False
        End If
    End Sub
    Private Sub chkBoxCervezas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxCervezas.CheckedChanged
        If chkBoxCervezas.Checked Then
            txtCantidad25.Enabled = True
            txtCantidad25.Visible = True
        Else
            txtCantidad25.Enabled = False
            txtCantidad25.Visible = False
        End If
    End Sub
    Private Sub chkBoxGaseosas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxGaseosas.CheckedChanged
        If chkBoxGaseosas.Checked Then
            txtCantidad26.Enabled = True
            txtCantidad26.Visible = True
        Else
            txtCantidad26.Enabled = False
            txtCantidad26.Visible = False
        End If
    End Sub
    Private Sub chkBoxVinos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxVinos.CheckedChanged
        If chkBoxVinos.Checked Then
            txtCantidad27.Enabled = True
            txtCantidad27.Visible = True
        Else
            txtCantidad27.Enabled = False
            txtCantidad27.Visible = False
        End If
    End Sub
    Private Sub chkBoxSalCriolla_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxSalCriolla.CheckedChanged
        If chkBoxSalCriolla.Checked Then
            txtCantidad28.Enabled = True
            txtCantidad28.Visible = True
        Else
            txtCantidad28.Enabled = False
            txtCantidad28.Visible = False
        End If
    End Sub
    Private Sub chkBoxWacamole_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxWacamole.CheckedChanged
        If chkBoxWacamole.Checked Then
            txtCantidad29.Enabled = True
            txtCantidad29.Visible = True
        Else
            txtCantidad29.Enabled = False
            txtCantidad29.Visible = False
        End If
    End Sub
    Private Sub chkBoxChedar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxChedar.CheckedChanged
        If chkBoxChedar.Checked Then
            txtCantidad30.Enabled = True
            txtCantidad30.Visible = True
        Else
            txtCantidad30.Enabled = False
            txtCantidad30.Visible = False
        End If
    End Sub
    Private Sub chkBoxVerdeo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxVerdeo.CheckedChanged
        If chkBoxVerdeo.Checked Then
            txtCantidad31.Enabled = True
            txtCantidad31.Visible = True
        Else
            txtCantidad31.Enabled = False
            txtCantidad31.Visible = False
        End If
    End Sub
    Private Sub chkBoxSalTartara_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxSalTartara.CheckedChanged
        If chkBoxSalTartara.Checked Then
            txtCantidad32.Enabled = True
            txtCantidad32.Visible = True
        Else
            txtCantidad32.Enabled = False
            txtCantidad32.Visible = False
        End If
    End Sub

    'DESHABILITO LA POSIBILIDAD DE INGRESAR OTRO TIPO DE CARACTER QUE NO SEA NUMERO A LAS TEXTBOX DONDE SE INGRESAN LAS CANTIDADES'

    Private Sub txtCantidad0_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad0.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad1.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad2.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad3.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad4.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad5.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad6.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad7.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad8.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad9.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad10.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad11.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad12.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad13.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad14.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad15.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad16_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad16.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad17_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad17.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad18_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad18.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad19_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad19.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad20_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad20.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad21_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad21.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad22_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad22.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad23_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad23.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad24_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad24.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad25_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad25.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad26_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad26.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad27_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad27.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad28_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad28.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad29_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad29.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad30_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad30.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad31_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad31.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub txtCantidad32_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad32.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub

    'BORRA LAYOUT DEL TEXTBOX DONDE SE INGRESA LA DIRECCION '

    Private Sub txtDireccion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDireccion.GotFocus
        txtDireccion.Clear()
        txtDireccion.ForeColor = Color.Black
    End Sub

    'HABILITACION DEL BOTON PAGAR SOLO SI SE SELECCIONO UN MEDIO DE PAGO'

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then ' PAGO EN EFECTIVO '
            btnPagar.Enabled = True
        End If

        If ComboBox1.SelectedIndex = 3 Then ' PAGO CON TRANSFERENCIA '
            btnPagar.Enabled = True
        End If


        If ComboBox1.SelectedIndex = 1 Then ' PAGO CON TARJETA DE CREDITO '
            btnPagar.Enabled = True
        End If

        If ComboBox1.SelectedIndex = 2 Then ' PAGO CON TARJETA DE DEBITO '
            btnPagar.Enabled = True
        End If

        If ComboBox1.SelectedIndex = -1 Then
            btnPagar.Enabled = False
        End If


    End Sub
End Class


