# COMP30019 Assignment 1 - Ray Tracer

**Name:** Hongji Huang \
**Student Number:** 1118640 \
**Username:** HOHUANG \
**Email:** hohuang@student.unimelb.edu.au

## Completed stages

Tick the stages bellow that you have completed so we know what to mark (by editing README.md). At most **six** marks can be chosen in total for stage three. If you complete more than this many marks, pick your best one(s) to be marked!


##### Stage 1

- [x] Stage 1.1 - Familiarise yourself with the template
- [x] Stage 1.2 - Implement vector mathematics
- [x] Stage 1.3 - Fire a ray for each pixel
- [x] Stage 1.4 - Calculate ray-entity intersections
- [x] Stage 1.5 - Output primitives as solid colours

##### Stage 2

- [x] Stage 2.1 - Diffuse materials
- [x] Stage 2.2 - Shadow rays
- [x] Stage 2.3 - Reflective materials
- [x] Stage 2.4 - Refractive materials
- [x] Stage 2.5 - The Fresnel effect
- [x] Stage 2.6 - Anti-aliasing

##### Stage 3

- [ ] Option A - Emissive materials (+6)
- [x] Option B - Ambient lighting/occlusion (+6)
- [ ] Option C - OBJ models (+6)
- [ ] Option D - Glossy materials (+3)
- [ ] Option E - Custom camera orientation (+3)
- [ ] Option F - Beer's law (+3)
- [ ] Option G - Depth of field (+3)

*Please summarise your approach(es) to stage 3 here.*



## Final scene render without Ambient lighting/occlusion

![My final render](./images/NoAmbientLight_8AntiAliasing_Final_Scene.png)

This render took **0** minutes and **10** seconds on my PC.

```
dotnet run -- -f tests/final_scene.txt -o images/NoAmbientLight_8AntiAliasing_Final_Scene.png -x 8
```
This image is an 8x Anti-Aliasing Final Scene without the AmbientLight and it took 10 seconds to render. The image with 4x  anti-aliasing only took 2.6 seconds to complete rendering. There are 6 different colour walls, 2 cubes, 1 diffuse sphere, 1 reflective sphere and 1 refractive sphere in the final scene.

## Final scene render with Ambient lighting/occlusion

![My final render](./images/6SampleNoAntiAliasing_Final_Scene.png)

This render took **1** minutes and **14** seconds on my PC.

```
dotnet run -- -f tests/final_scene.txt -o images/6SampleNoAntiAliasing_Final_Scene.png -x 1 -l
```
This image is a No Anti-Aliasing Final Scene with the AmbientLight and it took 74 seconds to render. It is obvious that the left-hand side of the left cube and right-hand side of the right cube has some colour from the wall, which is caused by Ambient light/occlusion. Because the number of samples is insufficient, there is a lot of noise in the picture, which becomes minimal as the number of samples increases. The AmbientLight Sample number can be set up in the Scene Class.

## Sample outputs

We have provided you with some sample tests located at ```/tests/*```. So you have some point of comparison, here are the outputs our ray tracer solution produces for given command line inputs (for the first two stages, left and right respectively):

###### Sample 1
```
dotnet run -- -f tests/sample_scene_1.txt -o images/sample_scene_1.png -x 4
```
<p float="left">
  <img src="./images/sample_scene_1_s1.png" />
  <img src="./images/sample_scene_1_s2.png" /> 
</p>

###### Sample 2

```
dotnet run -- -f tests/sample_scene_2.txt -o images/sample_scene_2.png -x 4
```
<p float="left">
  <img src="./images/sample_scene_2_s1.png" />
  <img src="./images/sample_scene_2_s2.png" /> 
</p>

## Sample Scene 1 With Ambient lighting/occlusion

```
dotnet run -- -f tests/sample_scene_1.txt -o images/128Sample_AmbientLighting_Scene_1.png -x 1 -l
```
<p float="left">
  <img src="./images/sample_scene_1_s2.png" />
  <img src="./images/128Sample_AmbientLighting_Scene_1.png" /> 
</p>
The Left Image is the sample output for Scene 1 of Stage 2 with 4 antiAliasing. The Right Image is the Scene 1 output with Ambient Lighting with 128 samples and no with antiAliasing. Compare these two outputs, it is obvious that there is a slight reddish tinge in the shadows of the sphere in the right image, which is due to Ambient lighting.

## References

Scratchapixel: intro to ray tracing: https://www.scratchapixel.com/lessons/3d-basic-rendering/introduction-to-ray-tracing/how-does-it-work

## Grading Report
**Final Grade:** 26.5  
**Additional Comments:** -  
   
7:49:47 PM: Building project C:\Users\Alex\Documents\GitHub\Project-1-Auto-Test\projects\Harrison-Huang666  
7:49:48 PM: STDOUT: 

Microsoft (R) Build Engine version 16.10.2+857e5a733 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  Restored C:\Users\Alex\Documents\GitHub\Project-1-Auto-Test\projects\Harrison-Huang666\RayTracer.csproj (in 140 ms).
  RayTracer -> C:\Users\Alex\Documents\GitHub\Project-1-Auto-Test\projects\Harrison-Huang666\report\bin\RayTracer.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:01.02  
7:49:48 PM: Success building project.  
### Stage 1
7:49:48 PM: Running test: 1_1_camera @ tests\Stage_1\1_1_camera~30s~-w_400_-h_300.txt  
7:49:48 PM: Iteration timeout: 30 seconds  
7:49:48 PM: Additional args: -w 400 -h 300  
7:49:48 PM: STDOUT: 

Execution Time: 24 ms  
7:49:48 PM: Render completed in **0.17 seconds** user processor time (raw = 0.17s).  

<p float="left">
<img src="./report/benchmarks\1_1_camera~30s~-w_400_-h_300.png" />
<img src="./report/outputs\1_1_camera~30s~-w_400_-h_300.png" />
</p>

7:49:48 PM: Running test: 1_2_primitives @ tests\Stage_1\1_2_primitives~30s.txt  
7:49:48 PM: Iteration timeout: 30 seconds  
7:49:48 PM: Additional args: none  
7:49:49 PM: STDOUT: 

Execution Time: 36 ms  
7:49:49 PM: Render completed in **0.31 seconds** user processor time (raw = 0.31s).  

<p float="left">
<img src="./report/benchmarks\1_2_primitives~30s.png" />
<img src="./report/outputs\1_2_primitives~30s.png" />
</p>

7:49:49 PM: Running test: 1_3_depth @ tests\Stage_1\1_3_depth~30s.txt  
7:49:49 PM: Iteration timeout: 30 seconds  
7:49:49 PM: Additional args: none  
7:49:49 PM: STDOUT: 

Execution Time: 47 ms  
7:49:49 PM: Render completed in **0.36 seconds** user processor time (raw = 0.36s).  

<p float="left">
<img src="./report/benchmarks\1_3_depth~30s.png" />
<img src="./report/outputs\1_3_depth~30s.png" />
</p>

### Stage 1 Rubric
---
- [x] Stage Attempted (+12 marks)
---
- [ ] Camera - FOV Incorrect (-1 marks)
- [x] Camera - Aspect Ratio Incorrect (-1 marks)
- [ ] Camera - Other Issue (minor) (-0.5 marks)
- [ ] Camera - Other Issue (major) (-1 marks)
---
- [ ] Shape - Plane Incorrect (-1 marks)
- [ ] Shape - Triangle Incorrect (-1 marks)
- [ ] Shape - Sphere Incorrect (-1 marks)
- [ ] Shape - Other Issue (minor) (-0.5 marks)
- [ ] Shape - Other Issue (major) (-1 marks)
---
- [ ] Depth - Wrong Order (1 case) (-1 marks)
- [ ] Depth - Wrong Order (2+ cases) (-2 marks)
- [ ] Depth - Other Issue (minor) (-0.5 marks)
- [ ] Depth - Other Issue (major) (-1 marks)
---
- [ ] Colour - Wrong Colour (1 case) (-1 marks)
- [ ] Colour - Wrong Colour (2+ cases) (-2 marks)
- [ ] Colour - Other Issue (minor) (-0.5 marks)
- [ ] Colour - Other Issue (major) (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage 2
7:49:49 PM: Running test: 2_1_diffuse @ tests\Stage_2\2_1_diffuse~60s.txt  
7:49:49 PM: Iteration timeout: 60 seconds  
7:49:49 PM: Additional args: none  
7:49:49 PM: STDOUT: 

Execution Time: 43 ms  
7:49:49 PM: Render completed in **0.48 seconds** user processor time (raw = 0.48s).  

<p float="left">
<img src="./report/benchmarks\2_1_diffuse~60s.png" />
<img src="./report/outputs\2_1_diffuse~60s.png" />
</p>

7:49:49 PM: Running test: 2_2_reflection @ tests\Stage_2\2_2_reflection~60s.txt  
7:49:49 PM: Iteration timeout: 60 seconds  
7:49:49 PM: Additional args: none  
7:49:49 PM: STDOUT: 

Execution Time: 39 ms  
7:49:49 PM: Render completed in **0.17 seconds** user processor time (raw = 0.17s).  

<p float="left">
<img src="./report/benchmarks\2_2_reflection~60s.png" />
<img src="./report/outputs\2_2_reflection~60s.png" />
</p>

7:49:49 PM: Running test: 2_3_refraction @ tests\Stage_2\2_3_refraction~300s.txt  
7:49:49 PM: Iteration timeout: 300 seconds  
7:49:49 PM: Additional args: none  
7:49:50 PM: STDOUT: 

Execution Time: 159 ms  
7:49:50 PM: Render completed in **1.86 seconds** user processor time (raw = 1.86s).  

<p float="left">
<img src="./report/benchmarks\2_3_refraction~300s.png" />
<img src="./report/outputs\2_3_refraction~300s.png" />
</p>

7:49:50 PM: Running test: 2_4_sample @ tests\Stage_2\2_4_sample~300s~-x_3.txt  
7:49:50 PM: Iteration timeout: 300 seconds  
7:49:50 PM: Additional args: -x 3  
7:49:51 PM: STDOUT: 

Execution Time: 818 ms  
7:49:51 PM: Render completed in **7.8 seconds** user processor time (raw = 7.8s).  

<p float="left">
<img src="./report/benchmarks\2_4_sample~300s~-x_3.png" />
<img src="./report/outputs\2_4_sample~300s~-x_3.png" />
</p>

### Stage 2 Rubric
---
- [x] Stage Attempted (+9 marks)
---
- [ ] Diffuse Light - No Output (-1 marks)
- [ ] Diffuse Light - Incorrect Equation/Normals (-1 marks)
- [ ] Diffuse Light - Other Issue (major) (-1 marks)
- [ ] Diffuse Light - Other Issue (minor) (-0.5 marks)
---
- [ ] Shadows - No Output (-1 marks)
- [ ] Shadows - Multiple Light Issues (-0.5 marks)
- [ ] Shadows - Other Issue (major) (-1 marks)
- [ ] Shadows - Other Issue (minor) (-0.5 marks)
---
- [ ] Reflection - No Output (-2 marks)
- [ ] Reflection - Partial Output (-1 marks)
- [ ] Reflection - Reflecting Refraction Issue (major) (-1 marks)
- [ ] Reflection - Reflecting Refraction Issue (minor) (-0.5 marks)
- [ ] Reflection - Other Issue (major) (-1 marks)
- [ ] Reflection - Other Issue (minor) (-0.5 marks)
---
- [ ] Refraction - No Output (-2 marks)
- [ ] Refraction - Partial Output (-1 marks)
- [x] Refraction - Recursivity Issue(s) (-0.5 marks)
- [x] Refraction - Non-Sphere Issue(s) (-0.5 marks)
- [ ] Refraction - Other Issue (major) (-1 marks)
- [ ] Refraction - Other Issue (minor) (-0.5 marks)
---
- [ ] Fresnel - No Output (-2 marks)
- [ ] Fresnel - Angle of Incidence Issue (-1 marks)
- [ ] Fresnel - Minor Artefact (-0.5 marks)
- [ ] Fresnel - Major Artefact (-1 marks)
---
- [ ] Anti-aliasing - No Output (-1 marks)
- [ ] Anti-aliasing - Minor Artefact (-0.5 marks)
- [ ] Anti-aliasing - Major Artefact (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage 3A
7:49:51 PM: Running test: 3A_1_baseline @ tests\Stage_3A\3A_1_baseline~60s.txt  
7:49:51 PM: Iteration timeout: 60 seconds  
7:49:51 PM: Additional args: none  
7:49:51 PM: STDOUT: 

Execution Time: 40 ms  
7:49:51 PM: Render completed in **0.36 seconds** user processor time (raw = 0.36s).  

<p float="left">
<img src="./report/benchmarks\3A_1_baseline~60s.png" />
<img src="./report/outputs\3A_1_baseline~60s.png" />
</p>

7:49:51 PM: Running test: 3A_2_emissive_low @ tests\Stage_3A\3A_2_emissive_low~1800s.txt  
7:49:51 PM: Iteration timeout: 1800 seconds  
7:49:51 PM: Additional args: none  
7:49:51 PM: STDOUT: 

Execution Time: 30 ms  
7:49:51 PM: Render completed in **0.34 seconds** user processor time (raw = 0.34s).  

<p float="left">
<img src="./report/benchmarks\3A_2_emissive_low~1800s.png" />
<img src="./report/outputs\3A_2_emissive_low~1800s.png" />
</p>

7:49:51 PM: Running test: 3A_3_emissive_med @ tests\Stage_3A\3A_3_emissive_med~1800s.txt  
7:49:51 PM: Iteration timeout: 1800 seconds  
7:49:51 PM: Additional args: none  
7:49:51 PM: STDOUT: 

Execution Time: 31 ms  
7:49:51 PM: Render completed in **0.5 seconds** user processor time (raw = 0.5s).  

<p float="left">
<img src="./report/benchmarks\3A_3_emissive_med~1800s.png" />
<img src="./report/outputs\3A_3_emissive_med~1800s.png" />
</p>

7:49:51 PM: Running test: 3A_4_emissive_high @ tests\Stage_3A\3A_4_emissive_high~1800s.txt  
7:49:51 PM: Iteration timeout: 1800 seconds  
7:49:51 PM: Additional args: none  
7:49:52 PM: STDOUT: 

Execution Time: 28 ms  
7:49:52 PM: Render completed in **0.42 seconds** user processor time (raw = 0.42s).  

<p float="left">
<img src="./report/benchmarks\3A_4_emissive_high~1800s.png" />
<img src="./report/outputs\3A_4_emissive_high~1800s.png" />
</p>

### Stage 3A Rubric
---
- [ ] Stage Attempted (+6 marks)
---
- [ ] Source - Invisible (-1 marks)
- [ ] Source - Emission Colour Incorrect (-1 marks)
- [ ] Source - Material Colour Incorrect (-1 marks)
- [ ] Source - Material Receives Illumination (-1 marks)
- [ ] Source - Other Issue (major) (-1 marks)
- [ ] Source - Other Issue (minor) (-0.5 marks)
---
- [ ] Soft Shadows - Not Present (all cases) (-5 marks)
- [ ] Soft Shadows - Not Present (one+ case) (-2 marks)
- [ ] Soft Shadows - Major Issue (-2 marks)
- [ ] Soft Shadows - Minor Issue (-1 marks)
---
- [ ] Noise - Incomprehensible Image (-6 marks)
- [ ] Noise - Not Justified (-2 marks)
- [ ] Noise - Partially Justified (-1 marks)
---
- [ ] Time - Complete Timeout (-6 marks)
- [ ] Time - Not Justified (-2 marks)
- [ ] Time - Partially Justified (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage 3B
7:49:52 PM: Running test: 3B_1_ambient @ tests\Stage_3B\3B_1_ambient~3600s~-l.txt  
7:49:52 PM: Iteration timeout: 3600 seconds  
7:49:52 PM: Additional args: -l  
7:50:04 PM: STDOUT: 

Execution Time: 12402 ms  
7:50:04 PM: Render completed in **1 minute, 22 seconds** user processor time (raw = 82.02s).  

<p float="left">
<img src="./report/benchmarks\3B_1_ambient~3600s~-l.png" />
<img src="./report/outputs\3B_1_ambient~3600s~-l.png" />
</p>

### Stage 3B Rubric
---
- [x] Stage Attempted (+6 marks)
---
- [ ] Indirect Light - None (-6 marks)
- [ ] Indirect Light - Partial or Unrealistic (-3 marks)
- [ ] Indirect Light - Incorrect Colour(s) (-2 marks)
- [ ] Indirect Light - Other Issue (major) (-1 marks)
- [ ] Indirect Light - Other Issue (minor) (-0.5 marks)
---
- [ ] Noise - Incomprehensible Image (-6 marks)
- [ ] Noise - Not Justified (-2 marks)
- [ ] Noise - Partially Justified (-1 marks)
---
- [ ] Time - Complete Timeout (-6 marks)
- [ ] Time - Not Justified (-2 marks)
- [ ] Time - Partially Justified (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** Well done!  
  
---

  
### Stage 3C
7:50:04 PM: Running test: 3C_1_baseline @ tests\Stage_3C\3C_1_baseline~1200s.txt  
7:50:04 PM: Iteration timeout: 1200 seconds  
7:50:04 PM: Additional args: none  
7:50:04 PM: STDOUT: 

Execution Time: 115 ms  
7:50:04 PM: Render completed in **0.94 seconds** user processor time (raw = 0.94s).  

<p float="left">
<img src="./report/benchmarks\3C_1_baseline~1200s.png" />
<img src="./report/outputs\3C_1_baseline~1200s.png" />
</p>

7:50:04 PM: Running test: 3C_2_obj @ tests\Stage_3C\3C_2_obj~1200s.txt  
7:50:04 PM: Iteration timeout: 1200 seconds  
7:50:04 PM: Additional args: none  
7:50:05 PM: STDOUT: 

Execution Time: 112 ms  
7:50:05 PM: Render completed in **0.92 seconds** user processor time (raw = 0.92s).  

<p float="left">
<img src="./report/benchmarks\3C_2_obj~1200s.png" />
<img src="./report/outputs\3C_2_obj~1200s.png" />
</p>

7:50:05 PM: Running test: 3C_3_obj @ tests\Stage_3C\3C_3_obj~1200s.txt  
7:50:05 PM: Iteration timeout: 1200 seconds  
7:50:05 PM: Additional args: none  
7:50:05 PM: STDOUT: 

Execution Time: 81 ms  
7:50:05 PM: Render completed in **0.7 seconds** user processor time (raw = 0.7s).  

<p float="left">
<img src="./report/benchmarks\3C_3_obj~1200s.png" />
<img src="./report/outputs\3C_3_obj~1200s.png" />
</p>

### Stage 3C Rubric
---
- [ ] Stage Attempted (+6 marks)
---
- [ ] Shape - Not Visible (-6 marks)
- [ ] Shape - Major Artefact(s) (-2 marks)
- [ ] Shape - Minor Artefact(s) (-1 marks)
- [ ] Shape - RH Coordinate System (-0.5 marks)
---
- [ ] Lighting - Incorrect Normals (-2 marks)
- [ ] Lighting - Unsmoothed Normals (-1 marks)
- [ ] Lighting - Material Issue(s) (-1 marks)
- [ ] Lighting - Other Issue (minor) (-0.5 marks)
- [ ] Lighting - Other Issue (major) (-1 marks)
---
- [ ] Reflection - Major Artefact(s) (-2 marks)
- [ ] Reflection - Minor Artefact(s) (-1 marks)
- [ ] Reflection - Other Issue (minor) (-0.5 marks)
- [ ] Reflection - Other Issue (major) (-1 marks)
---
- [ ] Time - Bunny >5x Sphere (-0.5 marks)
- [ ] Time - Bunny >10x Sphere (-1 marks)
- [ ] Time - Bunny >25x Sphere (-2 marks)
- [ ] Time - Bunny >100x Sphere (or downscale) (-3 marks)
- [ ] Time - Complete Timeout (-6 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage 3D
7:50:05 PM: Running test: 3D_1_glossy @ tests\Stage_3D\3D_1_glossy~1800s.txt  
7:50:05 PM: Iteration timeout: 1800 seconds  
7:50:05 PM: Additional args: none  
7:50:05 PM: STDOUT: 

Execution Time: 111 ms  
7:50:05 PM: Render completed in **1.05 seconds** user processor time (raw = 1.05s).  

<p float="left">
<img src="./report/benchmarks\3D_1_glossy~1800s.png" />
<img src="./report/outputs\3D_1_glossy~1800s.png" />
</p>

### Stage 3D Rubric
---
- [ ] Stage Attempted (+3 marks)
---
- [ ] Effect - Not Visible (-3 marks)
- [ ] Effect - Unconvincing (-2 marks)
- [ ] Effect - Partially convincing (-1 marks)
- [ ] Effect - Minor Issue/Artefact(s) (-0.5 marks)
---
- [ ] Technique - Overly Simple (-1 marks)
- [ ] Technique - Minor Issue (-0.5 marks)
- [ ] Technique - Major Issue (-1 marks)
---
- [ ] Time - Complete Timeout (-3 marks)
- [ ] Time - Not Justified (-2 marks)
- [ ] Time - Partially Justified (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage 3E
7:50:05 PM: Running test: 3E_1_camera @ tests\Stage_3E\3E_1_camera~30s~--cam-pos_0,2,-0.5_--cam-axis_1,0,0_--cam-angle_45.txt  
7:50:05 PM: Iteration timeout: 30 seconds  
7:50:05 PM: Additional args: --cam-pos 0,2,-0.5 --cam-axis 1,0,0 --cam-angle 45  
7:50:06 PM: STDOUT: 

Execution Time: 50 ms  
7:50:06 PM: Render completed in **0.52 seconds** user processor time (raw = 0.52s).  

<p float="left">
<img src="./report/benchmarks\3E_1_camera~30s~--cam-pos_0,2,-0.5_--cam-axis_1,0,0_--cam-angle_45.png" />
<img src="./report/outputs\3E_1_camera~30s~--cam-pos_0,2,-0.5_--cam-axis_1,0,0_--cam-angle_45.png" />
</p>

7:50:06 PM: Running test: 3E_2_camera @ tests\Stage_3E\3E_2_camera~30s~--cam-pos_0,2,-0.5_--cam-axis_1,0,0_--cam-angle_-45.txt  
7:50:06 PM: Iteration timeout: 30 seconds  
7:50:06 PM: Additional args: --cam-pos 0,2,-0.5 --cam-axis 1,0,0 --cam-angle -45  
7:50:06 PM: STDOUT: 

Execution Time: 48 ms  
7:50:06 PM: Render completed in **0.39 seconds** user processor time (raw = 0.39s).  

<p float="left">
<img src="./report/benchmarks\3E_2_camera~30s~--cam-pos_0,2,-0.5_--cam-axis_1,0,0_--cam-angle_-45.png" />
<img src="./report/outputs\3E_2_camera~30s~--cam-pos_0,2,-0.5_--cam-axis_1,0,0_--cam-angle_-45.png" />
</p>

7:50:06 PM: Running test: 3E_3_camera @ tests\Stage_3E\3E_3_camera~30s~--cam-pos_0,0,-1_--cam-axis_0,0.707,0.707_--cam-angle_20.txt  
7:50:06 PM: Iteration timeout: 30 seconds  
7:50:06 PM: Additional args: --cam-pos 0,0,-1 --cam-axis 0,0.707,0.707 --cam-angle 20  
7:50:06 PM: STDOUT: 

Execution Time: 40 ms  
7:50:06 PM: Render completed in **0.5 seconds** user processor time (raw = 0.5s).  

<p float="left">
<img src="./report/benchmarks\3E_3_camera~30s~--cam-pos_0,0,-1_--cam-axis_0,0.707,0.707_--cam-angle_20.png" />
<img src="./report/outputs\3E_3_camera~30s~--cam-pos_0,0,-1_--cam-axis_0,0.707,0.707_--cam-angle_20.png" />
</p>

### Stage 3E Rubric
---
- [ ] Stage Attempted (+3 marks)
---
- [ ] Position - Incorrect (1 case) (-1 marks)
- [ ] Position - Incorrect (2+ cases) (-2 marks)
---
- [ ] Rotation - Wrong Angle (-1 marks)
- [ ] Rotation - Wrong Angle Direction (-1 marks)
- [ ] Rotation - Incorrect (1 case) (-1 marks)
- [ ] Rotation - Incorrect (2+ cases) (-2 marks)
---
- [ ] Time - Complete Timeout (-3 marks)
- [ ] Time - Not Justified (-2 marks)
- [ ] Time - Partially Justified (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage 3F
7:50:06 PM: Running test: 3F_1_beers_room @ tests\Stage_3F\3F_1_beers_room~120s.txt  
7:50:06 PM: Iteration timeout: 120 seconds  
7:50:06 PM: Additional args: none  
7:50:06 PM: STDOUT: 

Execution Time: 188 ms  
7:50:06 PM: Render completed in **2.08 seconds** user processor time (raw = 2.08s).  

<p float="left">
<img src="./report/benchmarks\3F_1_beers_room~120s.png" />
<img src="./report/outputs\3F_1_beers_room~120s.png" />
</p>

7:50:06 PM: Running test: 3F_2_beers_pyramid @ tests\Stage_3F\3F_2_beers_pyramid~120s.txt  
7:50:06 PM: Iteration timeout: 120 seconds  
7:50:06 PM: Additional args: none  
7:50:07 PM: STDOUT: 

Execution Time: 182 ms  
7:50:07 PM: Render completed in **1.91 seconds** user processor time (raw = 1.91s).  

<p float="left">
<img src="./report/benchmarks\3F_2_beers_pyramid~120s.png" />
<img src="./report/outputs\3F_2_beers_pyramid~120s.png" />
</p>

### Stage 3F Rubric
---
- [ ] Stage Attempted (+3 marks)
---
- [ ] Colour - No Change (-3 marks)
- [ ] Colour - Hue Incorrect (-1 marks)
- [ ] Colour - Blending Issue (minor) (-1 marks)
- [ ] Colour - Blending Issue (major) (-2 marks)
- [ ] Colour - Absorbance Issue (minor) (-1 marks)
- [ ] Colour - Absorbance Issue (major) (-2 marks)
- [ ] Colour - Other Issue (minor) (-0.5 marks)
- [ ] Colour - Other Issue (major) (-1 marks)
---
- [ ] Shape - Sphere Issue (-1 marks)
- [ ] Shape - Non-Sphere Issue (-1 marks)
- [ ] Shape - Other Issue (minor) (-0.5 marks)
- [ ] Shape - Other Issue (major) (-1 marks)
---
- [ ] Time - Complete Timeout (-3 marks)
- [ ] Time - Not Justified (-2 marks)
- [ ] Time - Partially Justified (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage 3G
7:50:07 PM: Running test: 3G_1_dof @ tests\Stage_3G\3G_1_dof~1800s~--aperture-radius_0.06_--focal-length_1.5.txt  
7:50:07 PM: Iteration timeout: 1800 seconds  
7:50:07 PM: Additional args: --aperture-radius 0.06 --focal-length 1.5  
7:50:07 PM: STDOUT: 

Execution Time: 123 ms  
7:50:07 PM: Render completed in **1.38 seconds** user processor time (raw = 1.38s).  

<p float="left">
<img src="./report/benchmarks\3G_1_dof~1800s~--aperture-radius_0.06_--focal-length_1.5.png" />
<img src="./report/outputs\3G_1_dof~1800s~--aperture-radius_0.06_--focal-length_1.5.png" />
</p>

### Stage 3G Rubric
---
- [ ] Stage Attempted (+3 marks)
---
- [ ] Aperture - None/Incomprehensible Output (-3 marks)
- [ ] Aperture - Incorrect Size (-1 marks)
- [ ] Aperture - Other Issue (major) (-1 marks)
- [ ] Aperture - Other Issue (minor) (-0.5 marks)
---
- [ ] Focal Length - Incorrect Distance (-1 marks)
- [ ] Focal Length - Other Issue (major) (-1 marks)
- [ ] Focal Length - Other Issue (minor) (-0.5 marks)
---
- [ ] Time - Complete Timeout (-3 marks)
- [ ] Time - Not Justified (-2 marks)
- [ ] Time - Partially Justified (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage Final


<img src="./images/final_scene.png" />


### Stage Final Rubric
---
- [x] Final Image Attempted (+3 marks)
---
- [ ] Coverage - Little/None (-1 marks)
- [ ] Coverage - Partial (-0.5 marks)
---
- [ ] Quality - Little/None (-1 marks)
- [x] Quality - Partial (-0.5 marks)
---
- [ ] Creativity - Little/None (-1 marks)
- [x] Creativity - Partial (-0.5 marks)
---
- [x] Other - Repository Issue (minor) (-0.5 marks)
- [ ] Other - Repository Issue (major) (-1 marks)
- [ ] Other - README.md References Lacking (-1 marks)
- [ ] Other - README.md Utilised Incorrectly (-1 marks)
- [ ] Other - GitHub Not Utilised (-2 marks)
- [ ] Other - GitHub Incorrectly Utilised (-1 marks)
---
**Additional Comments:** Overall great work! (Minor repo issue: Wrong final image path/not specified properly)  
  
---

  
