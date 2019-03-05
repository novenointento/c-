
# Nombre del instalador
Name "Instalador corredores"

# The file to write
OutFile "corredores.exe"

# The default installation directory
InstallDir $PROGRAMFILES\Corredores

# Pedimos permisos para Windows 7
RequestExecutionLevel admin

# Pantallas que hay que mostrar del instalador

Page directory
Page instfiles

#Cambiar el idioma
!include "MUI.nsh"
!insertmacro MUI_LANGUAGE "Spanish"


#Seccion principal
Section

  # Establecemos el directorio de salida al directorio de instalacion
  SetOutPath $INSTDIR
  
  # Creamos el desinstalador
  writeUninstaller "$INSTDIR\uninstall.exe"
  
 
    # Creamos un acceso directo apuntando al desinstalador
	createDirectory "$SMPROGRAMS\AppCorredores\"
    createShortCut "$SMPROGRAMS\AppCorredores\Desinstalar.lnk" "$INSTDIR\uninstall.exe"
	createShortCut "$SMPROGRAMS\AppCorredores\corredores.lnk" "$INSTDIR\GestionCorredoresInterfazGrafica.jar"
  	createShortCut "$DESKTOP\corredores.lnk" "$INSTDIR\GestionCorredoresInterfazGrafica.jar"
  
  # Ponemos ahi el archivo test.txt
  File c:\original\GestionCorredoresInterfazGrafica.jar
  File /r c:\original\lib 
  File c:\original\corredores.csv
  File c:\original\carreras.dat
  File c:\original\opcionesConfiguracion.dat
  
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\corredores" \
                 "DisplayName" "Corredores"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\corredores" \
                 "Publisher" "Dani - Desarrollo Interfaces"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\corredores" \
                 "UninstallString" "$\"$INSTDIR\uninstall.exe$\""
  
# Fin de la seccion
SectionEnd

# seccion del desintalador
Section "uninstall"
 
    # borramos el desintalador primero
    Delete "$INSTDIR\uninstall.exe"
	Delete "$INSTDIR\corredores.csv"
	Delete "$INSTDIR\carreras.dat"
	Delete "$INSTDIR\opcionesConfiguracion.dat"
    Delete "$INSTDIR\GestionCorredoresInterfazGrafica.jar"
	Delete "$SMPROGRAMS\AppCorredores\Desinstalar.lnk"
	Delete "$SMPROGRAMS\AppCorredores\corredores.lnk"
	RMDir "$SMPROGRAMS\AppCorredores"
	Delete "$DESKTOP\corredores.lnk" 
	RMDir /r "$INSTDIR\lib"
	
    RMDir "$INSTDIR"
	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\corredores"
 
# fin de la seccion del desinstalador
sectionEnd
