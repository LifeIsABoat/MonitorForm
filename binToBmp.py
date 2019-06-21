#coding=utf-8
import os
import sys
from PIL import Image

#Lcd表示バッファのデータからBMPへ転換する
BINFILEPATH = os.getcwd()
BMPWDITH = 120
BMPLENGTH = 320
BINFILEBYTENUM = 0x12C0

#1文字バッファのデータからBMPへ転換する
# BINFILEPATH = os.path.abspath("..") + "\\1wordBuf\\"
# BMPWDITH = 64
# BMPLENGTH = 120
# BINFILEBYTENUM = 0x3C0
'''
/*
;------------------------------------------------------------------------------
;	モジュール名	:	
;	機能概要		:	Lcd表示バッファのbinファイルからbmpファイルへ変更する
;	入力情報		:	
;	出力情報		:	なし
;	戻り値		:	なし
;	作成日		:	
;	作成者		:	
;	特記事項		:
;------------------------------------------------------------------------------
*/
'''
if __name__ == '__main__':
	binData = []

	intputPath = sys.argv[1]
	outputPath = sys.argv[2]
	if intputPath.endswith('.bin') or intputPath.endswith('.BIN'):
		# print bpath
		bmp = Image.new('RGB',(BMPLENGTH,BMPWDITH))
		count = 0
		binfile = open(intputPath,'rb')
		for i in range(0, BINFILEBYTENUM):
			temp = binfile.read(1)
			binData.append(int(str(ord(temp)).replace("0x","")))

		for h in range(0,BMPWDITH):
			for w in range(0,BMPLENGTH):
				num = (count / 8)
				data = binData[num]
				index = 7 - (count % 8)
				binStr = bin(data)
				binStr = binStr.replace("0b","")
				binLen = len(binStr)
				if(binLen < 8):
					for i in range(0,8 - binLen):
						binStr = "0" + binStr

				if(binStr[index]=="1"):
					bmp.putpixel([BMPLENGTH - w - 1,BMPWDITH - h -1 ],(0,0,0))
				else:
					bmp.putpixel([BMPLENGTH - w - 1,BMPWDITH - h -1 ],(255,255,255))

				count = count + 1
		print outputPath
		# print bpath
		bmp.save(outputPath)
	del binData[:]
