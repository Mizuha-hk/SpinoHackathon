# �t�����g�G���h�v����`
## �g�p�Z�p

Blazor WebAssembly

## ���[�e�B���O
### �g�b�v�y�[�W
route: `/`

�A�v���̃g�b�v�y�[�W�B���O�C�����Ă��Ȃ��ꍇ�̓��O�C����ʂɃ��_�C���N�g�����B
�^�C�����C�����\�������B

### ���O�C���y�[�W
route: `/login`

���O�C����ʁBEmail�ƃp�X���[�h����͂��ă��O�C������B
�T�C���A�b�v�y�[�W�ւ̃����N������B

### �T�C���A�b�v�y�[�W
route: `/signup`

�T�C���A�b�v��ʁB���O�AEmail�A�p�X���[�h����͂��ăA�J�E���g���쐬����B


### ���[�U�[�y�[�W
route: `/users/:id`

���[�U�[�̃v���t�B�[���y�[�W�B���[�U�[�̖��O�A�v���t�B�[���摜�A�t�H���[���A�t�H�����[���A���e���A�t�H���[�{�^�����\�������B
���[�U�[�̓��e���\�������B
�����̃y�[�W�̏ꍇ�̓v���t�B�[���ҏW�{�^�����\�������B

### ���[�U�[�ҏW�y�[�W
route: `/users/:id/edit`

���[�U�[�̃v���t�B�[���ҏW�y�[�W�B���O�A�v���t�B�[���摜�A���ȏЉ��ҏW�ł���B

### ���e�ڍ׃y�[�W

route: `/posts/:id`

���e�̏ڍ׃y�[�W�B���e�̓��e�A���e�҂̖��O�A���e�����A�����ː��A�R�����g���A�����˃{�^���A�R�����g�t�H�[���A�R�����g�ꗗ���\�������B

### �g�����h�y�[�W
route: `/trends`

�g�����h�̈ꗗ�y�[�W�B�g�����h���e�̈ꗗ���\�������B

### �ʒm�y�[�W

route: `/notifications`

�ʒm�̈ꗗ�y�[�W�B�t�H���[�A�����ˁA�R�����g�̒ʒm���\�������B

### notfound�y�[�W

route: `/notfound`

�y�[�W��������Ȃ��ꍇ�ɕ\�������y�[�W�B

### fobidden�y�[�W

route: `/fobidden`

�A�N�Z�X�������Ȃ��ꍇ�ɕ\�������y�[�W�B

### error�y�[�W

route:`/error`

�G���[�����������ꍇ�ɕ\�������y�[�W�B

### �y�[�W�J��
```mermaid
graph TD
    top[�g�b�v�y�[�W] -->|���O�C�����Ă��Ȃ�| login[���O�C���y�[�W]
    login -->|���O�C������| top
    login -->|�T�C���A�b�v| signup[�T�C���A�b�v�y�[�W]
    signup -->|�A�J�E���g�쐬/���O�C��| top
    top -->|���[�U�[�I��| user[���[�U�[�y�[�W]
    user -->|�����̃y�[�W| user-edit[���[�U�[�ҏW�y�[�W]
    top -->|�g�����h�^�u�I��| trend[�g�����h�y�[�W]
    top -->|�ʒm�^�u�I��| notification[�ʒm�y�[�W]
    
    top -->|���e�I��| detail[���e�ڍ׃y�[�W]
    user -->|���e�I��| detail
    notification -->|���e�I��| detail
    trend -->|���e�I��| detail
```