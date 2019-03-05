
#Seccion principal
Section

  # Establecemos el directorio de salida al directorio de instalacion
  SetOutPath $INSTDIR
  
  # Creamos el desinstalador
  writeUninstaller "$INSTDIR\uninstall.exe"
  
 
    # Creamos un acceso directo apuntando al desinstalador
	createDirectory "$SMPROGRAMS\AppAvituallamientos\"
    createShortCut "$SMPROGRAMS\AppAvituallamientos\Desinstalar.lnk" "$INSTDIR\uninstall.exe"
	createShortCut "$SMPROGRAMS\AppAvituallamientos\AppAvituallamientos.lnk" "$INSTDIR\Proyecto2EvaluacionDI.exe"
  	createShortCut "$DESKTOP\AppAvituallamientos.lnk" "$INSTDIR\Proyecto2EvaluacionDI.exe"
  
  # Ponemos ahi el archivo test.txt
  File C:\Users\daniel\Documents\Proyecto2EvaluacionDI.exe

  
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AppAvituallamientos" \
                 "DisplayName" "AppAvituallamientos"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AppAvituallamientos" \
                 "Publisher" "Dani - Desarrollo Interfaces"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AppAvituallamientos" \
                 "UninstallString" "$\"$INSTDIR\uninstall.exe$\""
  
# Fin de la seccion
SectionEnd

# seccion del desintalador
Section "uninstall"
 
    # borramos el desintalador primero
    Delete "$INSTDIR\uninstall.exe"
    Delete "$INSTDIR\Proyecto2EvaluacionDI.exe"
	Delete "$SMPROGRAMS\AppAvituallamientos\Desinstalar.lnk"
	Delete "$SMPROGRAMS\AppAvituallamientos\AppAvituallamientos.lnk"
	RMDir "$SMPROGRAMS\AppAvituallamientos"
	Delete "$DESKTOP\AppAvituallamientos.lnk" 
	

	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AppAvituallamientos"
 
# fin de la seccion del desinstalador
sectionEnd
