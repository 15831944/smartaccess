;CommonFunc.nsh
;ͨ�ò���
!macro BadPathsCheck
StrCpy $R0 $INSTDIR "" -1
StrCmp $R0 ":" bad
StrCpy $R0 $INSTDIR "" -2
StrCmp $R0 ":\" bad
StrCpy $R0 $INSTDIR "" -14
StrCmp $R0 "\Program Files" bad
StrCpy $R0 $INSTDIR "" -15
StrCmp $R0 "\Program Files\" bad
StrCpy $R0 $INSTDIR "" -20
StrCmp $R0 "\Program Files (x86)" bad
StrCpy $R0 $INSTDIR "" -21
StrCmp $R0 "\Program Files (x86)\" bad
StrCpy $R0 $INSTDIR "" -8
StrCmp $R0 "\Windows" bad
StrCpy $R0 $INSTDIR "" -9
StrCmp $R0 "\Windows\" bad
StrCpy $R0 $INSTDIR "" -6
StrCmp $R0 "\WinNT" bad
StrCpy $R0 $INSTDIR "" -7
StrCmp $R0 "\WinNT\" bad
StrCpy $R0 $INSTDIR "" -9
StrCmp $R0 "\system32" bad
StrCpy $R0 $INSTDIR "" -10
StrCmp $R0 "\system32\" bad
StrCpy $R0 $INSTDIR "" -7
StrCmp $R0 "\system" bad
StrCpy $R0 $INSTDIR "" -8
StrCmp $R0 "\system\" bad
StrCpy $R0 $INSTDIR "" -8
StrCmp $R0 "\Desktop" bad
StrCpy $R0 $INSTDIR "" -9
StrCmp $R0 "\Desktop\" bad
StrCpy $R0 $INSTDIR "" -22
StrCmp $R0 "\Documents and Settings" bad
StrCpy $R0 $INSTDIR "" -23
StrCmp $R0 "\Documents and Settings\" bad

StrCpy $R0 $INSTDIR "" -4
StrCmp $R0 "\123" bad
StrCpy $R0 $INSTDIR "" -5
StrCmp $R0 "\123\" bad

StrCpy $R0 $INSTDIR "" -13
StrCmp $R0 "\My Documents" bad
StrCpy $R0 $INSTDIR "" -14
StrCmp $R0 "\My Documents\" bad done
bad:
Push "1"
Goto BadPathsCheckEnd
done:
Push "0"
BadPathsCheckEnd:
!macroend



!include CheckDotNetFramework.nsh

;�ж��Ƿ�װMicrosoft .NET Framework
;����1 �汾�ţ� ����2 ִ���ļ�λ��
Function InstallDotNetFramework
        ;��ȡ����
        Pop $R1
        Pop $R0
        Var /GLOBAL DotNetFrameworkVersion
        Var /GLOBAL DotNetFrameworkFile
        StrCpy $DotNetFrameworkVersion $R0
        StrCpy $DotNetFrameworkFile $R1

        DetailPrint "����Ƿ�װMicrosoft .NET Framework $DotNetFrameworkVersion"

        !define DOTNETNAME "Microsoft .NET Framework $DotNetFrameworkVersion"
        Push $DotNetFrameworkVersion
        Call CheckDotNetFramework
        Exch $R0
        ${If} $R0 == "1" ; û���ҵ�
                DetailPrint "��ʼ��װ ${DOTNETNAME}..."
                DetailPrint "��װ Microsoft .NET Framework $DotNetFrameworkVersion ��ʱ��Ƚϳ��������ĵȴ���"
                ExecWait '"$DotNetFrameworkFile" /q /norestart /ChainingPackage FullX64Bootstrapper'
                DetailPrint "��ɰ�װ $DotNetFrameworkFile ."
        ${ElseIf} $R0 == "0" ; �ҵ�ָ���汾��DotNetFramework
                DetailPrint "�Ѱ�װ ${DOTNETNAME}"
                Delete $DotNetFrameworkFile
        ${Endif}
FunctionEnd

;��װFLashPlayer
Function InstallFlashPlayer
         Pop $R0
         DetailPrint "��ʼ��װ $R0..."
         ExecWait '"$R0" /install'
         DetailPrint "��ɰ�װ $R0."
FunctionEnd

Function InstallSoftware
         Pop $R0
         DetailPrint "��ʼ��װ $R0..."
         ExecWait '"$R0" /Q'
         DetailPrint "��ɰ�װ $R0."
FunctionEnd

Var /GLOBAL ProductExeName
;�رս���
Function CloseProcess
  Pop $R0
  StrCpy $ProductExeName $R0
  CheckProc:
    Push "$ProductExeName"
    ProcessWork::existsprocess
    Pop $R0
    IntCmp $R0 0 Done
    MessageBox MB_OKCANCEL|MB_ICONSTOP "��װ�����⵽ $ProductExeName �������С�$\r$\n$\r$\n��� ��ȷ���� ǿ�ƹر� $ProductExeName��������װ��$\r$\n��� ��ȡ���� �˳���װ����" IDCANCEL Exit
    Push "$ProductExeName"
    Processwork::KillProcess
    Sleep 1000
    Goto CheckProc
    Exit:
    Abort
    Done:
    ;Pop $R0
FunctionEnd
;�رս���
Function un.CloseProcess
  Pop $R0
  StrCpy $ProductExeName $R0
  CheckProc:
    Push "$ProductExeName"
    ProcessWork::existsprocess
    Pop $R0
    IntCmp $R0 0 Done
    MessageBox MB_OKCANCEL|MB_ICONSTOP "��װ�����⵽ $ProductExeName �������С�$\r$\n$\r$\n��� ��ȷ���� ǿ�ƹر� $ProductExeName��������װ��$\r$\n��� ��ȡ���� �˳���װ����" IDCANCEL Exit
    Push "$ProductExeName"
    Processwork::KillProcess
    Sleep 1000
    Goto CheckProc
    Exit:
    Abort
    Done:
    ;Pop $R0
FunctionEnd