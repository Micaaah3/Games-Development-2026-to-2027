# B(inary) I(mage) O(verlap) T(est) BIOT

Quite simply if you drew (rendered) two images (Bitmap or Sprite) and they tried to both draw on the same pixel, a collision was detected.

This was often done (or aided by) hardware.

This, while being pixel perfect, was not perfect in practice

<img width="263" height="546" alt="image" src="https://github.com/user-attachments/assets/d42a8300-b737-4622-88fb-1cfc3b6937b1" />

In this image, the sprite with 2 yellow pixels is moving 1 unity to the right each frame while the green is moving 1 unit to the left. It is possible for these sprites to pass right through each other without any pixel ever clashing to trigger a collision.


This apart, how was it done?

Firstly, how were sprites represented?

"On" pixels were seen as ones, and "off" as 0 turning each row into a binary number

<img width="456" height="368" alt="image" src="https://github.com/user-attachments/assets/619e52ba-eb52-469c-ba35-072bc5ad1447" />

Conversely if we wanted to draw an image, given the rows as numbers

<img width="659" height="114" alt="image" src="https://github.com/user-attachments/assets/a38eac87-15ef-4c52-a2c5-90f9f94e3909" />



<img width="472" height="270" alt="image" src="https://github.com/user-attachments/assets/2d4e53bc-e197-4a13-b5f9-c0f9054d03fa" />


In practice, we end up with a situation like ...

<img width="684" height="104" alt="image" src="https://github.com/user-attachments/assets/890504e4-1ce2-4957-8a62-b3b9aa679a8d" />


Overlaying one sprite over the other in the appropriate place allows us to determine if collision has occured


<img width="587" height="447" alt="image" src="https://github.com/user-attachments/assets/7ae0a3b7-8c74-40cf-80ff-cfdbbd951b34" />





<img width="956" height="632" alt="image" src="https://github.com/user-attachments/assets/828e258e-fc37-4637-8d52-3db50cebed0d" />
