;InstallThirdPart.nsh
;��������װ
!include CommonFunc.nsh
!include CheckVcRedist.nsh
!define THIRDPART_OUT_PATH "ThirdPart"
!define THIRDPART_PATH "ThirdParts"
!define DOTNET_FRAMEWORK_40_EXE "dotNetFx40_Full_x86_x64.exe"
!define FLASH_PLAYER_EXE "flashplayer.exe"
!define VC_2005_EXE "vcredist2005_x86.exe"
!define VC_2008_EXE "vcredist2008_x86.exe"
!define VC_2010_EXE "vcredist2010_x86.exe"
!define VC_2012_EXE "vcredist2012_x86.exe"
!define THIRDPART_EXE_PATH "$TEMP\${THIRDPART_OUT_PATH}"

Function InstallThirdPart
      DetailPrint "��ʼ��װ������..."

      SetOutPath "${THIRDPART_EXE_PATH}"
      SetOverwrite on
      File /r "${THIRDPART_PATH}\*"

 ;��ʼ��װ4.0
      Push "4.0"
      Push "${THIRDPART_EXE_PATH}\${DOTNET_FRAMEWORK_40_EXE}"
      Call InstallDotNetFramework
      
;��װFlashPlayer
 ;     Push "${THIRDPART_EXE_PATH}\${FLASH_PLAYER_EXE}"
 ;     Call InstallFlashPlayer
      
;��װVC 2005
 ;     Push "2005"
 ;     Call CheckVcRedist
;      Pop $R0
 ;     StrCmp $R0 0 +3 0
 ;     Push "${THIRDPART_EXE_PATH}\${VC_2005_EXE}"
  ;    Call InstallSoftware

;��װVC 2008
  ;    Push "2008"
   ;   Call CheckVcRedist
   ;   Pop $R0
  ;    StrCmp $R0 0 +3 0
  ;    Push "${THIRDPART_EXE_PATH}\${VC_2008_EXE}"
   ;   Call InstallSoftware

;��װVC 2010
 ;     Push "2010"
  ;    Call CheckVcRedist
;      Pop $R0
;      StrCmp $R0 0 +3 0
;     Push "${THIRDPART_EXE_PATH}\${VC_2010_EXE}"
 ;     Call InstallSoftware

;��װVC 2012
  ;    Push "2012"
  ;    Call CheckVcRedist
   ;   Pop $R0
   ;   StrCmp $R0 0 +3 0
   ;   Push "${THIRDPART_EXE_PATH}\${VC_2012_EXE}"
  ;    Call InstallSoftware
      
      Delete "${THIRDPART_EXE_PATH}\*"
      RMDIR /r "${THIRDPART_EXE_PATH}"
      
      DetailPrint "��ɰ�װ��������"

FunctionEnd
