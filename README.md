# Image to Text in C&num;


This repository contains sample C# source code referenced in the tutorial documentation for **IronOCR**.
https://ironsoftware.com/csharp/ocr/


## Dependancies

The Iron OCR library for .Net

```
 PM > Install-Package IronOcr
```


## Example 1

Example 1 explores the **AutoOcr** Class an shows that OCR can be performed in a single line of C# code in a .Net Project

This technique works for OCR on Images, Screenshots, Scans, Photographs and PDF documents.

## Example 2

Example 2 shows the **AdvancedOcr** Class.

It also demonstrated IronOCR key feature - it is highly successful in performing OCR on low quality input images and documents.

Even with skew, rotation. text distortion and digital noise, there is only a 0.9% drop in OCR accuracy and no major loss of speed for OCR.

## Example 3

Example 3 shows how to use a **System.Drawing.Rectangle** to perform OCR on a specified region ("crop-region") of a document.

## Example 4

Example 4 shows the use af an [OCR language pack](https://ironsoftware.com/csharp/ocr/languages/) to read Arabic text in C#.


```
PM> Install-Package IronOcr.Languages.Arabic
```
### Other International OCR Languages 

22 OCR languages are supported including:

* Arabic
* ChineseSimplified
* ChineseTraditional
* Czech
* Danish
* Finnish
* French
* German
* Greek
* Hebrew
* Hungarian
* Italian
* Japanese
* Korean
* Norwegian
* Polish
* Portuguese
* Russian
* Spanish
* Swedish
* Thai
* Turkish