//-----------------------------------------------------------------------------
// Torque Game Engine
// 
// Copyright (c) 2001 GarageGames.Com
// Portions Copyright (c) 2001 by Sierra Online, Inc.
//-----------------------------------------------------------------------------

//--------------------------------------------------------------------------

$Gui::fontCacheDirectory = expandFilename("./cache");
$Gui::clipboardFile      = expandFilename("./cache/clipboard.gui");

// GuiDefaultProfile is a special case, all other profiles are initialized
// to the contents of this profile first then the profile specific
// overrides are assigned.

if(!IsObject(GuiDefaultProfile)) new GuiControlProfile (GuiDefaultProfile)
{
   tab = false;
   canKeyFocus = false;
   hasBitmapArray = false;
   mouseOverSelected = false;

   // fill color
   opaque = false;
   fillColor = ($platform $= "macos") ? "211 211 211" : "192 192 192";
   fillColorHL = ($platform $= "macos") ? "244 244 244" : "220 220 220";
   fillColorNA = ($platform $= "macos") ? "244 244 244" : "220 220 220";

   // border color
   border = false;
   borderColor   = "0 0 0";
   borderColorHL = "128 128 128";
   borderColorNA = "64 64 64";

   // font
   fontType = "Arial";
   fontSize = 14;

   fontColor = "0 0 0";
   fontColorHL = "32 100 100";
   fontColorNA = "0 0 0";
   fontColorSEL= "200 200 200";

   // bitmap information
   bitmap = ($platform $= "macos") ? "./osxWindow" : "./darkWindow";
   bitmapBase = "";
   textOffset = "0 0";

   // used by guiTextControl
   modal = true;
   justify = "left";
   autoSizeWidth = false;
   autoSizeHeight = false;
   returnTab = false;
   numbersOnly = false;
   cursorColor = "0 0 0 255";

   // sounds
   soundButtonDown = "";
   soundButtonOver = "";
};

if(!IsObject(GuiInputCtrlProfile)) new GuiControlProfile( GuiInputCtrlProfile )
{
   tab = true;
	canKeyFocus = true;
};

if(!IsObject(GuiDialogProfile)) new GuiControlProfile(GuiDialogProfile);


if(!IsObject(GuiSolidDefaultProfile)) new GuiControlProfile (GuiSolidDefaultProfile)
{
   opaque = true;
   border = true;
};

if(!IsObject(GuiWindowProfile)) new GuiControlProfile (GuiWindowProfile)
{
   opaque = true;
   border = 2;
   fillColor = ($platform $= "macos") ? "211 211 211" : "192 192 192";
   fillColorHL = ($platform $= "macos") ? "190 255 255" : "64 150 150";
   fillColorNA = ($platform $= "macos") ? "255 255 255" : "150 150 150";
   fontColor = ($platform $= "macos") ? "0 0 0" : "255 255 255";
   fontColorHL = ($platform $= "macos") ? "200 200 200" : "0 0 0";
   text = "GuiWindowCtrl test";
   bitmap = ($platform $= "macos") ? "./osxWindow" : "./darkWindow";
   textOffset = ($platform $= "macos") ? "5 5" : "6 6";
   hasBitmapArray = true;
   justify = ($platform $= "macos") ? "center" : "left";
};

if(!IsObject(GuiToolWindowProfile)) new GuiControlProfile (GuiToolWindowProfile)
{
   opaque = true;
   border = 2;
   fillColor = "192 192 192";
   fillColorHL = "64 150 150";
   fillColorNA = "150 150 150";
   fontColor = "255 255 255";
   fontColorHL = "0 0 0";
   bitmap = "./torqueToolWindow";
   textOffset = "6 6";
};

if(!IsObject(EditorToolButtonProfile)) new GuiControlProfile (EditorToolButtonProfile)
{
   opaque = true;
   border = 2;
};

if(!IsObject(GuiContentProfile)) new GuiControlProfile (GuiContentProfile)
{
   opaque = true;
   fillColor = "255 255 255";
};

if(!IsObject(GuiModelessDialogProfile)) new GuiControlProfile("GuiModelessDialogProfile")
{
   modal = false;
};

if(!IsObject(GuiButtonProfile)) new GuiControlProfile (GuiButtonProfile)
{
   opaque = true;
   border = true;
   fontColor = "0 0 0";
   fontColorHL = "32 100 100";
   fixedExtent = true;
   justify = "center";
	canKeyFocus = false;
};

if(!IsObject(GuiBorderButtonProfile)) new GuiControlProfile (GuiBorderButtonProfile)
{
   fontColorHL = "0 0 0";
};

if(!IsObject(GuiMenuBarProfile)) new GuiControlProfile (GuiMenuBarProfile)
{
   opaque = true;
   fillColorHL = "0 0 96";
   border = 4;
   fontColor = "0 0 0";
   fontColorHL = "255 255 255";
   fontColorNA = "128 128 128";
   fixedExtent = true;
   justify = "center";
   canKeyFocus = false;
   mouseOverSelected = true;
   bitmap = ($platform $= "macos") ? "./osxMenu" : "./torqueMenu";
   hasBitmapArray = true;
};

if(!IsObject(GuiButtonSmProfile)) new GuiControlProfile (GuiButtonSmProfile : GuiButtonProfile)
{
   fontSize = 14;
};

if(!IsObject(GuiRadioProfile)) new GuiControlProfile (GuiRadioProfile)
{
   fontSize = 14;
   fillColor = "232 232 232";
   fontColorHL = "32 100 100";
   fixedExtent = true;
   bitmap = ($platform $= "macos") ? "./osxRadio" : "./torqueRadio";
   hasBitmapArray = true;
};

if(!IsObject(GuiScrollProfile)) new GuiControlProfile (GuiScrollProfile)
{
   opaque = true;
   fillColor = "255 255 255";
   border = 3;
   borderThickness = 2;
   borderColor = "0 0 0";
   bitmap = ($platform $= "macos") ? "./osxScroll" : "./darkScroll";
   hasBitmapArray = true;
};

if(!IsObject(GuiSliderProfile)) new GuiControlProfile (GuiSliderProfile);

if(!IsObject(GuiTextProfile)) new GuiControlProfile (GuiTextProfile)
{
   fontColor = "0 0 0";
   fontColorLink = "255 96 96";
   fontColorLinkHL = "0 0 255";
   autoSizeWidth = true;
   autoSizeHeight = true;
};

if(!IsObject(EditorTextProfile)) new GuiControlProfile (EditorTextProfile)
{
   fontType = "Arial Bold";
   fontColor = "0 0 0";
   autoSizeWidth = true;
   autoSizeHeight = true;
};

if(!IsObject(EditorTextProfileWhite)) new GuiControlProfile (EditorTextProfileWhite)
{
   fontType = "Arial Bold";
   fontColor = "255 255 255";
   autoSizeWidth = true;
   autoSizeHeight = true;
};

if(!IsObject(GuiMediumTextProfile)) new GuiControlProfile (GuiMediumTextProfile : GuiTextProfile)
{
   fontSize = 24;
};

if(!IsObject(GuiBigTextProfile)) new GuiControlProfile (GuiBigTextProfile : GuiTextProfile)
{
   fontSize = 36;
};

if(!IsObject(GuiCenterTextProfile)) new GuiControlProfile (GuiCenterTextProfile : GuiTextProfile)
{
   justify = "center";
};

if(!IsObject(MissionEditorProfile)) new GuiControlProfile (MissionEditorProfile)
{
   canKeyFocus = true;
};

if(!IsObject(EditorScrollProfile)) new GuiControlProfile (EditorScrollProfile)
{
   opaque = true;
   fillColor = "192 192 192 192";
   border = 3;
   borderThickness = 2;
   borderColor = "0 0 0";
   bitmap = "./darkScroll";
   hasBitmapArray = true;
};

if(!IsObject(GuiTextEditProfile)) new GuiControlProfile (GuiTextEditProfile)
{
   opaque = true;
   fillColor = "255 255 255";
   fillColorHL = "128 128 128";
   border = 3;
   borderThickness = 2;
   borderColor = "0 0 0";
   fontColor = "0 0 0";
   fontColorHL = "255 255 255";
   fontColorNA = "128 128 128";
   textOffset = "0 2";
   autoSizeWidth = false;
   autoSizeHeight = true;
   tab = true;
   canKeyFocus = true;
};

if(!IsObject(GuiControlListPopupProfile)) new GuiControlProfile (GuiControlListPopupProfile)
{
   opaque = true;
   fillColor = "255 255 255";
   fillColorHL = "128 128 128";
   border = true;
   borderColor = "0 0 0";
   fontColor = "0 0 0";
   fontColorHL = "255 255 255";
   fontColorNA = "128 128 128";
   textOffset = "0 2";
   autoSizeWidth = false;
   autoSizeHeight = true;
   tab = true;
   canKeyFocus = true;
   bitmap = ($platform $= "macos") ? "./osxScroll" : "./darkScroll";
   hasBitmapArray = true;
};

if(!IsObject(GuiTextArrayProfile)) new GuiControlProfile (GuiTextArrayProfile : GuiTextProfile)
{
   fontColorHL = "32 100 100";
   fillColorHL = "200 200 200";
};

if(!IsObject(GuiTextListProfile)) new GuiControlProfile (GuiTextListProfile : GuiTextProfile) ;

if(!IsObject(GuiTreeViewProfile)) new GuiControlProfile (GuiTreeViewProfile)
{
   fontSize = 13;  // dhc - trying a better fit...
   fontColor = "0 0 0";
   fontColorHL = "64 150 150";
};

if(!IsObject(GuiCheckBoxProfile)) new GuiControlProfile (GuiCheckBoxProfile)
{
   opaque = false;
   fillColor = "232 232 232";
   border = false;
   borderColor = "0 0 0";
   fontSize = 14;
   fontColor = "0 0 0";
   fontColorHL = "32 100 100";
   fixedExtent = true;
   justify = "left";
   bitmap = ($platform $= "macos") ? "./osxCheck" : "./torqueCheck";
   hasBitmapArray = true;

};

if(!IsObject(GuiPopUpMenuProfile)) new GuiControlProfile (GuiPopUpMenuProfile)
{
   opaque = true;
   mouseOverSelected = true;

   border = 4;
   borderThickness = 2;
   borderColor = "0 0 0";
   fontSize = 14;
   fontColor = "0 0 0";
   fontColorHL = "32 100 100";
   fontColorSEL = "32 100 100";
   fixedExtent = true;
   justify = "center";
   bitmap = ($platform $= "macos") ? "./osxScroll" : "./darkScroll";
   hasBitmapArray = true;
};

if(!IsObject(GuiEditorClassProfile)) new GuiControlProfile (GuiEditorClassProfile)
{
   opaque = true;
   fillColor = "232 232 232";
   border = true;
   borderColor   = "0 0 0";
   borderColorHL = "127 127 127";
   fontColor = "0 0 0";
   fontColorHL = "32 100 100";
   fixedExtent = true;
   justify = "center";
   bitmap = ($platform $= "macos") ? "./osxScroll" : "./darkScroll";
   hasBitmapArray = true;
};


if(!IsObject(LoadTextProfile)) new GuiControlProfile ("LoadTextProfile")
{
   fontColor = "66 219 234";
   autoSizeWidth = true;
   autoSizeHeight = true;
};


if(!IsObject(GuiMLTextProfile)) new GuiControlProfile ("GuiMLTextProfile")
{
   fontColorLink = "255 96 96";
   fontColorLinkHL = "0 0 255";
};

if(!IsObject(GuiMLTextEditProfile)) new GuiControlProfile (GuiMLTextEditProfile) 
{ 
   fontColorLink = "255 96 96"; 
   fontColorLinkHL = "0 0 255"; 

   fillColor = "255 255 255"; 
   fillColorHL = "128 128 128"; 

   fontColor = "0 0 0"; 
   fontColorHL = "255 255 255"; 
   fontColorNA = "128 128 128"; 

   autoSizeWidth = true; 
   autoSizeHeight = true; 
   tab = true; 
   canKeyFocus = true; 
}; 

//--------------------------------------------------------------------------
// Console Window

if(!IsObject(GuiConsoleProfile)) new GuiControlProfile ("GuiConsoleProfile")
{
   fontType = ($platform $= "macos") ? "Courier New" : "Lucida Console";
   fontSize = 12;
   fontColor = "0 0 0";
   fontColorHL = "130 130 130";
   fontColorNA = "255 0 0";
   fontColors[6] = "50 50 50";
   fontColors[7] = "50 50 0";  
   fontColors[8] = "0 0 50"; 
   fontColors[9] = "0 50 0";   
};


if(!IsObject(GuiProgressProfile)) new GuiControlProfile ("GuiProgressProfile")
{
   opaque = false;
   fillColor = "44 152 162 100";
   border = true;
   borderColor   = "78 88 120";
};

if(!IsObject(GuiProgressTextProfile)) new GuiControlProfile ("GuiProgressTextProfile")
{
   fontColor = "0 0 0";
   justify = "center";
};



//--------------------------------------------------------------------------
// Gui Inspector

if(!IsObject(GuiInspectorTextEditProfile)) new GuiControlProfile ("GuiInspectorTextEditProfile")
{
   opaque = true;
   fillColor = "255 255 255";
   fillColorHL = "128 128 128";
   border = true;
   borderColor = "0 0 0";
   fontColor = "0 0 0";
   fontColorHL = "255 255 255";
   autoSizeWidth = false;
   autoSizeHeight = true;
   tab = false;
   canKeyFocus = true;
};

if(!IsObject(GuiBitmapBorderProfile)) new GuiControlProfile(GuiBitmapBorderProfile)
{
   bitmap = "./darkBorder";
   hasBitmapArray = true;
};

//-------------------------------------- Cursors
//
new GuiCursor(DefaultCursor)
{
   hotSpot = "1 1";
   bitmapName = "./CUR_3darrow";
};

