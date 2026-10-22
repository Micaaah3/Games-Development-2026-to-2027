# Modeling

Model vertices are 3D points (x,y,z) defined relative to an origin which is, by convention, in the centre of mass of that object. The reason for this is that, scaling and rotation by default work around the centre

<img width="714" height="556" alt="image" src="https://github.com/user-attachments/assets/49db7f45-3756-41ef-9172-f8ee1f41e820" />

The problem with this is that it only describes 8 points in space, to really see the cube, or any other model, we need to describe the surface of it.

## How do we describe the surface of a model?

The surface is always described as a sequences of triangles, which we call faces.

Rather than describing each vertex a vector (x,y,z) we give it a name (index of an array or list)

<img width="681" height="564" alt="image" src="https://github.com/user-attachments/assets/135d9ae2-575c-4da2-a2e6-8299bdc32221" />

So the model geometry will need 2 lists, a vertex list and a face (index) list

<img width="240" height="307" alt="image" src="https://github.com/user-attachments/assets/e75b1151-609c-46df-b1e0-e8b7644609e7" />

All faces must be described in the same direction (usually counter-clockwise) so that back face culling may be implemented.

<img width="250" height="400" alt="image" src="https://github.com/user-attachments/assets/1bb4ac5c-1e86-45cc-bf9d-56e4fdf2f8ca" />

## Texturing

The process of texturing, basically maps each of the triangles of the face (index) list to a specified triangle in an image file (called a Texture)

For Example: If we specify that 1 goes on the top, it is reasonably clear what mapping is desired.

<img width="423" height="556" alt="image" src="https://github.com/user-attachments/assets/618a9d0c-0b21-4656-a1c9-4e5751cb8830" />


As before, we need to be able to describe the triangles, this time on the 2D texture. So we need a new list of Texture Vertices, so we define and lable with indices as before./
<img width="526" height="579" alt="image" src="https://github.com/user-attachments/assets/f40195a1-a6ad-4b54-874e-c609d8bf66a6" />


<img width="207" height="488" alt="image" src="https://github.com/user-attachments/assets/af1c67f0-f365-499f-b90c-24c98c9ea955" />


<img width="516" height="398" alt="image" src="https://github.com/user-attachments/assets/271fa3e5-6fbb-4fbd-b7b8-5bc800e89511" />

## Normals

Finally Normals are used in Lighting, and each face has a normal which is a unit vector perpendicular to the surface of the face.


<img width="975" height="558" alt="image" src="https://github.com/user-attachments/assets/e1180ed3-0e57-4635-b4fe-eefc17df46e7" />




